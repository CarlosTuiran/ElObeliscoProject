import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { ProductosService } from '../../productos/productos.service';
import { element } from 'protractor';

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
        'rgba(200,200,0,0.9)',
        'rgba(0,210,0,0.9)',
        'rgba(255,0,0,0.9)',
        'rgba(136,136,136,0.9)',
        'rgba(136,136,136,0.9)'
      ]
    }
  ];
  productos:any;
  producto:any;

  constructor(private service: ProductosService) { }

  ngOnInit(): void {
  
  }

  loadData(event: any): void {
        this.service.top10Productos().subscribe(
        data => {
         /* //const last = data.pop();
          data.forEach(i => {
            this.pieChartData[i] = data[i].cantidad,
              this.pieChartLabels[i] = data[i].descripcion;
          });
          //this.pieChartData[0] = last;*/
          console.log(data);
        }, error => console.error(error)
    );
    
  }

  

  clear(): void {
    this.pieChartData = [];
  }

}
