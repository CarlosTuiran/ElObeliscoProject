import { Component, OnInit } from '@angular/core';
import { TotalLiquidacionService } from './total-liquidacion.service';

@Component({
  selector: 'app-total-liquidacion',
  templateUrl: './total-liquidacion.component.html',
  styleUrls: ['./total-liquidacion.component.css']
})
export class TotalLiquidacionComponent implements OnInit {

  constructor(private totalLiquidacionService:TotalLiquidacionService) { }
  totalLiquidaciones: ITotalLiquidacion[];
  
  ngOnInit() {
    this.totalLiquidacionService.getTotalLiquidaciones()
      .subscribe(totalLiquidaciones => this.totalLiquidaciones = totalLiquidaciones,
        error => console.error(error));
  }

}

export interface ITotalLiquidacion {
  mes: number,
  anio: number,
  valorTotalNomina: number,
  sueldo: number,
  subTransporte: number,
  totalDevengado: number,
  salud_Empleador: number,
  salud_Trabajador: number,
  salud: number,
  pension_Trabajador: number,
  pension_Empleador: number,
  pension: number,
  prima: number,
  cesantias: number,
  int_Cesantias: number,
  vacaciones: number,
  arl: number,
  caja_Comp: number,
  iCBF: number,
  sENA: number,
  retencionAporteNomina: number,
  acreedoresVarios: number,
  provision: number,
  salariosPagar: number,
  parafiscales: number,
  nominaId: string,
}

export interface IDTotalLiquidacion {
  idNomina:string
}
