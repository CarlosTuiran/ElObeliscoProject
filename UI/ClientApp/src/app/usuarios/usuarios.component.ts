import { DataTablesResponse } from '../tablas/data-tables-response';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UsuariosService } from './usuarios.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios: IUsuario[];
  dtOptions: DataTables.Settings = {};

   
  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    

    this.usuariosService.getUsuarios()
      //los usuarios que vengan desde el web service añadelos a la lista de usuarios de esta clase
      .subscribe(usuarios => this.usuarios = usuarios,
        error => console.error(error));



  }
}
export interface IUsuario {
   nombre: string, 
   password: string,
   empleadoId:number, 
}
