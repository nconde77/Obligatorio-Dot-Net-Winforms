import {Deserializable} from './deserializable.model';

export class User implements Deserializable {

  public Nombre: string;
  public Apellido: string;
  public Email: string;
  public Roles: any;

  constructor() {

  }

  public deserialize(input: any) {
    Object.assign(this, input);

    return this;
  }
}
