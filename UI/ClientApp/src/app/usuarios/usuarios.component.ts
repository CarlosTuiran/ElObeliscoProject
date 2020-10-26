import { DataTablesResponse } from '../tablas/data-tables-response';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UsuariosService } from './usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  usuarios: IUsuario[];
  dtOptions: DataTables.Settings = {};

  //inyeccion del servicio que se comunicara con la web api
  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.usuariosService.getUsuarios()
      //los usuarios que vengan desde el web service añadelos a la lista de usuarios de esta clase
      .subscribe(usuarios => this.usuarios = usuarios,
        error => console.error(error));

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      info: true,
      language: {
        emptyTable: '',
        zeroRecords: 'No hay coincidencias',
        lengthMenu: 'Mostrar _MENU_ elementos',
        search: 'Buscar:',
        info: 'De _START_ a _END_ de _TOTAL_ elementos',
        infoEmpty: 'De 0 a 0 de 0 elementos',
        infoFiltered: '(filtrados de _MAX_ elementos totales)',
        paginate: {
          first: 'Prim.',
          last: 'Últ.',
          next: 'Sig.',
          previous: 'Ant.'
        },
      },
    }
  }
}
export interface IUsuario {
   nombre: string, 
   password: string,
   empleadoId:number, 
   tipo: string  
}
