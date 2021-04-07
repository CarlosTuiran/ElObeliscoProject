import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { EmpleadosService } from './empleados.service';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent implements OnInit {

  empleados: IEmpleado[];
  dtOptions: DataTables.Settings = {};

  //inyeccion del servicio que se comunicara con la web api
  constructor(private empleadosService: EmpleadosService) { }

  ngOnInit() {
      this.empleadosService.getEmpleados()
      //los usuarios que vengan desde el web service añadelos a la lista de usuarios de esta clase
      .subscribe(empleados => this.empleados = empleados,
        error => console.error(error));
  }
}
export interface IEmpleado{
  idEmpleado:number,
  nombres:string,
  apellidos:string,
  cargo:string,
  celular:string,
  correo:string,
  direccion: string,
  fechaIngreso: Date  
}

export interface IDeleteEmpleado {
  idEmpleado: number
}
