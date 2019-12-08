import {Injectable} from '@angular/core';
import {JwtHelperService} from '@auth0/angular-jwt';
import {User} from '../models/user.model';
import {HttpClient, HttpParams} from '@angular/common/http';
import {environment as ENV} from '../../environments/environment';
const JWT_ACCESS_TOKEN_NAME = 'access_token';

export function jwtOptionsFactory(storage) {
  return {
    tokenGetter: () => {
      // return storage.get(JWT_ACCESS_TOKEN_NAME);
      // tslint:disable-next-line: max-line-length
      return 'eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJpYXQiOjE1MjYyMjEwNTYsImV4cCI6MTU1Nzg0MzQ1Niwicm9sZXMiOlsiUk9MRV9VU0VSIl0sInVzZXJuYW1lIjoibm1vcmUyMSJ9.X2xY3Wi8b7s6pVP4DM-EMUMTeYrOoVq4jAFFXVDwUf9knHSYyLbZQIEXbfRUOlYHiYqtASnBBQD3PbwlDsfYTRwI5CpIkqSTxKUbSfFSySKpmQIUcqKGdiVtZs8GwX1aut0h9opIGWRD5JFcRk_1b7KdCWvqyK7VTmGgwxVE_tXU08HG5xMqUqZfeAg6CcgXEqBF8BKbpsrs7ZZAifOBh542c0wIu5wBxmUSOwAutoqkl8gn8mF20Btm9daM33Fg4F4KB4nnwQOR1MfdEO1iew3g5PNjnvynx_6OYr46IKRkWb5znKLMQmelzgj-BsUj2hlQwmH9TbV0jN1SoxFnsoQ6eBkwsMlCsgoB8Shym80yLKyURwJAHpwSOo2D5qR95oVTYnbXgsCO_YW0TxBhTZwfqp1Rlkj2HTTWB_Sn5Q29DByb3TTZ0OUC-u9Cw7Uc_IC8TqurKI_FzCcdt3MpHEa0nvByl79bCFR7_kftWspCrdGq7VqVkD1RjgMnL1a7iPUT4kB7WICvV8VXnqTr-28XQMDWrX-cBWbYmQUZwGDmqyPSLNJeZU2x9ZdWeYGzKR3-2EqDOToMzbCWPsLZ4_idORKjl8-mTpYtKkvzFXYR9hjfQsf5eZUWRyWKBh4Sj8r2dAZgjL_AZOwrrMB53PZF_y9FgyWO3Ft7zl8WlsA';
    },
    whitelistedDomains: []
  };
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  public isAuthenticated = false;
  public user: User = null;

  // tslint:disable-next-line: max-line-length
  constructor(public http: HttpClient, private jwtHelper: JwtHelperService) {

  }

  public checkAuthenticated(): Promise<boolean> {

    return new Promise((resolve, reject) => {
      // resolve(true);
      const token = localStorage.getItem(JWT_ACCESS_TOKEN_NAME);
      if (token) {
        if (this.jwtHelper.isTokenExpired(token)) {
          localStorage.removeItem(JWT_ACCESS_TOKEN_NAME);
          this.isAuthenticated = false;
          console.log('isTokenExpired');
          resolve(false);
        } else {
          this.isAuthenticated = true;
          console.log('token ok');
          resolve(true);
        }
      } else {
        this.isAuthenticated = false;
        resolve(false);
      }
    });
  }

  public register(username: string, password: string, nombre: string, apellido: string): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this.http.post(ENV.api_dev_url + '/auth/register', {
        username,
        password,
        nombre,
        apellido
      }).toPromise().then((response: any) => {
        console.dir(response);
        resolve(true);
      })
      .catch((reason: any) => {
        resolve(reason);
      });
    });
  }

  public login(username: string, password: string): Promise<boolean> {
    return new Promise((resolve, reject) => {
      this.http.post(ENV.api_dev_url + '/auth/login', {
        username,
        password
      }).toPromise().then((response: any) => {
        console.dir(response);
        localStorage.setItem(JWT_ACCESS_TOKEN_NAME, response.token);
        this.isAuthenticated = true;
        resolve(true);
      })
      .catch((reason: any) => {
        console.dir(reason);
        this.isAuthenticated = false;
        resolve(reason);
      });
    });
  }

  public logout() {
    this.isAuthenticated = false;

    return localStorage.removeItem(JWT_ACCESS_TOKEN_NAME);
  }
}
