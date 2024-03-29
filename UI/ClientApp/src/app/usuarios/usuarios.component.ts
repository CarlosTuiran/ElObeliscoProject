import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UsuariosService } from './usuarios.service';
import { MatTableDataSource } from '@angular/material/table';
import { error } from 'jquery';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios: IUsuario[]; 

   
  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.usuariosService.getUsuarios()
      .subscribe(usuarios => this.usuarios = usuarios,
        error => console.error(error));
  }
}
export interface IUsuario {
   nombre: string, 
   password: string,
   empleadoId:number, 
   rol:string
}
