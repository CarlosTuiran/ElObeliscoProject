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
  sena: number,
  icbf: number,
  comfacesar: number,
  total: number,
  nominaId: string
}

export interface IDTotalLiquidacion {
  idNomina:string
}
