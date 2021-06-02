import { DataTablesResponse } from '../tablas/data-tables-response';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { NominaService } from './nomina.service';
import { LiquidacionService } from '../liquidacion/liquidacion.service';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-nomina',
  templateUrl: './nomina.component.html',
  styleUrls: ['./nomina.component.css']
})
export class NominaComponent implements OnInit {

  nominas: INomina[];


  constructor(private nominaService: NominaService, private liquidacionService: LiquidacionService, private router: Router) { }

  ngOnInit() {
  }

}
export interface INomina {  
  idNomina: string,
  idEmpleado: number,
  nombreEmpleado: string,
  diasTrabajados: number,
  horaExtraDiurna: number,
  horaExtraDiurnaFestivo: number,
  horaExtraNocturna: number,
  horaExtraNocturnaFestivo: number,
  salarioBase: number,
  comisiones: number
}
export interface INominaPago{
  idEmpleado: number
}
export interface IDeleteNomina {
  idEmpleado: number,
  idNomina: string
}
