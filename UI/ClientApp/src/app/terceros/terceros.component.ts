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

  }

}
export interface ITercero {
  nit: string,
  nombre: string,
  apellido: string,
  tipoTercero: string,
  celular: string,
  correo: string,
  direccion: string,
  ciudad: string,
  telefono: string,
  descripcion: string,
  fechaCumple: Date
}
export interface IDeleteTercero {
  nit: string
}
