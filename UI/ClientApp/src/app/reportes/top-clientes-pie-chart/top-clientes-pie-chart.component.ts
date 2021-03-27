import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { FormBuilder } from '@angular/forms';
import { Label, SingleDataSet } from 'ng2-charts';
import { element } from 'protractor';
import { ReportesService } from '../reportes.service';
import { IInterval } from '../reportes.component';
//import { MatFormFieldModule, MatInputModule } from '@angular/material';

@Component({
  selector: 'app-top-clientes-pie-chart',
  templateUrl: './top-clientes-pie-chart.component.html',
  styleUrls: ['./top-clientes-pie-chart.component.css']
})
export class TopClientesPieChartComponent implements OnInit {

 

  //array  que contiene la descripcion de los top 10
  proveedoresLabel: string[]=[];

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
  constructor(private service: ReportesService, private fb: FormBuilder) { }

  formGroup = this.fb.group({
    fechaInicio:[''],
    fechaFin:[''],
  });

  ngOnInit(): void {
    this.service.Top10Clientes().subscribe(
      data => {
       
        for(let item of data){
          this.pieChartData[this.i] = item.total,
          this.pieChartLabels[this.i] = item.nombre;
          this.i=this.i+1;
        }

      }, error => console.error(error)
  );
  }

  loadData(event: any): void {}

  

  clear(): void {
    this.pieChartData = [];
    this.proveedoresLabel=[];
    this.i=0;
  }
  dataFilter()
  {
    let interval:  IInterval = Object.assign({}, this.formGroup.value);
    this.service.Top10ClientesInterval(interval).subscribe(
      data => {
        this.clear();
        for(let item of data){
          this.pieChartData[this.i] = item.total,
          this.pieChartLabels[this.i] = item.nombre;
          this.i=this.i+1;
        }

      }, error => console.error(error)
      )
  } 
  get fechaInicio() {
    return this.formGroup.get('fechaInicio');
  }
  get fechaFin() {
    return this.formGroup.get('fechaFin');
  }
}
