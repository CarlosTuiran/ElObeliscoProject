import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { element } from 'protractor';
import { ReportesService } from '../reportes.service';

@Component({
  selector: 'app-inventario-pie-chart',
  templateUrl: './inventario-pie-chart.component.html',
  styleUrls: ['./inventario-pie-chart.component.css']
})
export class InventarioPieChartComponent implements OnInit {

  //array  que contiene la descripcion de los top 10
  productosLabel: string[]=[];

  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels: Label[] = [];
  public pieChartData: SingleDataSet = [];
  public pieChartType: ChartType = 'pie';
  public pieChartLegend = true;
  public pieChartPlugins = [];
  public pieChartColors: any = [
    {
      backgroundColor: [
        'rgba(200,200,0,0.9)',
        'rgba(0,210,0,0.9)',
        'rgba(255,0,0,0.9)',
        'rgba(136,136,136,0.9)',
        'rgba(230,230,0,0.9)',
        'rgba(100,210,0,0.9)',
        'rgba(155,0,0,0.9)',
        'rgba(236,136,136,0.9)',
        'rgba(236,236,136,0.9)'
      ]
    }
  ];
  public i =0;
  constructor(private service: ReportesService) { }

  ngOnInit(): void {
    this.service.Top10Productos().subscribe(
      data => {
       
        for(let item of data){
          this.pieChartData[this.i] = item.cantidad,
          this.pieChartLabels[this.i] = item.descripcion;
          this.i=this.i+1;
        }

      }, error => console.error(error)
  );
  }

  loadData(event: any): void {}

  

  clear(): void {
    this.pieChartData = [];
  }

}
