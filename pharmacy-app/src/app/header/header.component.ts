import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  public loginService: LoginService = null;

  construct(loginService: LoginService) {
    this.loginService = loginService;
    this.loginService.checkAuthenticated();

  }

  ngOnInit() {
  }

}
