import { Component, OnInit } from '@angular/core';
import { DataTablesResponse } from '../tablas/data-tables-response';
import { TercerosService } from './terceros.service';
 
@Component({
  selector: 'app-terceros',
  templateUrl: './terceros.component.html',
  styleUrls: ['./terceros.component.css']
})
export class TercerosComponent implements OnInit {

  terceros: ITercero[];
  dtOptions: DataTables.Settings = {};

  constructor(private tercerosService: TercerosService) { }

  ngOnInit() {
    this.tercerosService.getTerceros()
      .subscribe(terceros => this.terceros = terceros,
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
      ajax: (dataTablesParameters: any, callback) => {

      },
      columns: [{ data: 'doi' }, { data: 'nombre' }, { data: 'fecha_de_ingreso' }]
    }
  }

}
export interface ITercero {
  nit: string,
  nombre: string,
  apellidos: string,
  tipoTercero: string,
  celular: string,
  correo: string,
  direccion: string,
  descripcion: string
}
