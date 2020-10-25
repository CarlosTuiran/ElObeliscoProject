import { DataTablesResponse } from '../tablas/data-tables-response';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UsuariosService } from './usuarios.service';

declare var $: any;
declare var jQuery: any;

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  @ViewChild('dataTable', { static: true }) table:ElementRef;
  //lista de Usuarios que tendra la pagina
  usuarios: IUsuario[];
  datatable: any;
  dtOptions: any;
  //dtOptions: DataTables.Settings = {};
  NumberOfItems = 0;

  //inyeccion del servicio que se comunicara con la web api
  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    /*this.usuariosService.getUsuarios()
      //los usuarios que vengan desde el web service añadelos a la lista de usuarios de esta clase
      .subscribe(usuarios => this.usuarios = usuarios,
        error => console.error(error));*/

    /*this.dtOptions = {
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
      ajax: (dataTablesParameters: any, callback) => {
        this.usuariosService.http
        .get<DataTablesResponse>(
          this.usuariosService.apiURL,
          dataTablesParameters
        ).subscribe(resp => {
            resp => this.usuarios = resp.data;
            resp=>this.NumberOfItems = resp.data.length;
            $('.dataTables_length>label>select, .dataTables_filter>label>input').addClass('form-control-sm');
            callback({
              recordsTotal: resp.recordsTotal,
              recordsFiltered: resp.recordsFiltered,
              data: []
            });
            if (this.NumberOfItems > 0) {
              $('.dataTables_empty').css('display', 'none');
            }
          }
          );
      },
      columns: [{ data: 'nombre' }, { data: 'password' }, { data: 'empleadoId' },{ data: 'tipo' } ]
    };*/
    this.dtOptions = {
      "ajax": {
        url: this.usuariosService.apiURL,
        type: 'GET',
        dataType:'json',
        dataFilter: function (resp) { debugger; return resp; },
        error: function (err) { debugger;}
      },
      columns:[
        {
        title: 'Nombre',
          data:'nombre'
        },
        {
          title: 'Password',
          data: 'password'
        },
        {
          title: 'EmpleadoId',
          data: 'empleadoId'
        },
        {
          title: 'Tipo',
          data: 'tipo'
        }
        ]
    };
    this.datatable = $(this.table.nativeElement);
    this.datatable.DataTable(this.dtOptions);
  }

}
export interface IUsuario {
   nombre: string, 
   password: string,
   empleadoId:number, 
   tipo: string  
}
