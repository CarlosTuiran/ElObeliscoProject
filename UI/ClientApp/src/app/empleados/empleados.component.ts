import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export interface IEmpleado{
  idEmpleado:number,
  nombres:string,
  apellidos:string,
  cargo:string,
  celular:string,
  correo:string,
  direccion:string,
  estado:string
}