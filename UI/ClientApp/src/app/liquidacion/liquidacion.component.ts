import { DataTablesResponse } from '../tablas/data-tables-response';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { LiquidacionService } from './liquidacion.service';
import { TotalLiquidacionService } from '../total-liquidacion/total-liquidacion.service';
import { error } from '@angular/compiler/src/util';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-liquidacion',
  templateUrl: './liquidacion.component.html',
  styleUrls: ['./liquidacion.component.css']
})
export class LiquidacionComponent implements OnInit {

  liquidaciones: ILiquidacion[];

  constructor(private liquidacionService: LiquidacionService, private totalLiquidacionService: TotalLiquidacionService, private router: Router) { }

  ngOnInit() {
    this.liquidacionService.getLiquidaciones()
      .subscribe(liquidaciones => this.liquidaciones = liquidaciones,
        error => console.error(error));
  }

  Total() {
    this.totalLiquidacionService.createTotalLiquidacion().subscribe(totalLiquidacion => this.onSaveSuccess()),
      error => console.error();
  }

  onSaveSuccess() {
    this.router.navigate(["/total-liquidaciones"]);
  }

}
export interface ILiquidacion {
  nominaId: string,
  idEmpleado: number,
  mes: number,
  anio: number,
  sueldoOrdinario: number,
  subTransporte: number,
  totalDevengado: number,
  salud: number,
  pension: number,
  totalDeducido: number,
  totalPagar: number
}

export interface ITotal {
  nominaId: string,
  mes: number,
  anio: number
}


