import { Component, OnInit } from '@angular/core';
import { AlertService } from '../notifications/_services';
import { ReportesService } from '../reportes/reportes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  
  message = "Bienvenido a el sistema de Informacion ElObelisco";
  card: ICard[];

  constructor(private alertService: AlertService, private reportesService: ReportesService){
  
  }
  
  ngOnInit() {
    this.alertService.info(this.message);
    this.reportesService.PromedioVentas
  }
  
}

export interface ICard{
  mes_Descripcion: string,
  total: number
}
@Input() icon: string;
@Input() title: string;
@Input() value: number;
@Input() color: string;
@Input() isIncrease: boolean;
@Input() isCurrency: boolean;
@Input() duration: string;
@Input() percentValue: number;
