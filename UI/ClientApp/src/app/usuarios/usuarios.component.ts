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

   
  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
  }
}
export interface IUsuario {
   nombre: string, 
   password: string,
   empleadoId:number, 
   tipo:string
}
