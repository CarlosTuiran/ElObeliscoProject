import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { element } from 'protractor';
import { ReportesService } from '../reportes.service';
import { FormBuilder } from '@angular/forms';
import { IInterval } from '../reportes.component';

@Component({
  selector: 'app-top-proveedores-pie-chart',
  templateUrl: './top-proveedores-pie-chart.component.html',
  styleUrls: ['./top-proveedores-pie-chart.component.css']
})
export class TopProveedoresPieChartComponent implements OnInit {

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

  ngOnInit(): void {
    this.service.Top10Proveedores().subscribe(
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
  formGroup = this.fb.group({
    fechaInicio:[''],
    fechaFin:[''],
  });
  dataFilter()
  {
    let interval:  IInterval = Object.assign({}, this.formGroup.value);
    this.service.Top10ProveedoresInterval(interval).subscribe(
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
