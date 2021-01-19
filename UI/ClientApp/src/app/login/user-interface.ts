/*export interface UserInterface {
  id?: string;
  name?: string;
  user?: string;
  password?: string;
}*/
//Nuevo Metodo
export type Roles='Admin'|'Empleado';
export interface User{
usuario: string;
password: string;
}
export interface UserResponse{
message: string;
token: string;
userId: number;
rol: Roles;
}