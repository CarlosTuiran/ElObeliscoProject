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
    this.nominaService.getNominas()
      .subscribe(nominas => this.nominas = nominas,
        error => console.error(error));
  }

  Pagar(idNomina: string, idEmpleado: number) {
    let nomina: INominaPago = { 'idEmpleado': idEmpleado };
    console.table(nomina);
    this.liquidacionService.createLiquidacion(nomina)
        .subscribe(usuario => this.onSaveSuccess(),
          error => console.error(error));
  }

  onSaveSuccess() {
    this.router.navigate(["/liquidaciones"]);
  }
}
export interface INomina {
  idEmpleado: number,
  idNomina: string,
  diasTrabajados: number,
  horasExtras: number,
  salarioBase: number,
  subTransporte: number
}
export interface INominaPago{
  idEmpleado: number
}
export interface IDeleteNomina {
  idEmpleado: number,
  idNomina: string
}
