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
  identificacion: string,
  tipoId: string,
  nombre: string,
  apellido: string,
  tipoTercero: string,
  tipoPersona:string,
  actividadEconomica:string,
  responsabilidadFiscal:string,
  responsableIva:bool,
  autoRetenedor:bool,
  extranjero:bool,
  celular: string,
  correo: string,
  direccion: string,
  ciudad: string,
  telefono: string,
  descripcion: string,
  fechaCumple: Date
}
export interface IDeleteTercero {
  identificacion: string
}
