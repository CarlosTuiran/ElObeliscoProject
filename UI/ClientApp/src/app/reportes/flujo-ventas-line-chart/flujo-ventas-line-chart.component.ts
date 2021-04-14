import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { BaseChartDirective, Color, Label } from 'ng2-charts';
import { IInterval } from '../reportes.component';
import { ReportesService } from '../reportes.service';

@Component({
  selector: 'app-flujo-ventas-line-chart',
  templateUrl: './flujo-ventas-line-chart.component.html',
  styleUrls: ['./flujo-ventas-line-chart.component.css']
})
export class FlujoVentasLineChartComponent implements OnInit {

  public lineChartData: ChartDataSets[];
  public lineChartLabels: Label[] = [];
  public lineChartOptions: (ChartOptions) = {
    responsive: true,
    scales: {
      // We use this empty structure as a placeholder for dynamic theming.
      xAxes: [{}],
      yAxes: [
        {
          id: 'y-axis-0',
          position: 'left',
        }
      ]
    }   
  };
  public lineChartColors: Color[] = [
    { // grey
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    { // red
      backgroundColor: 'rgba(255,0,0,0.3)',
      borderColor: 'red',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    }
  ];
  public lineChartLegend = true;
  public lineChartType: ChartType = 'line';
  //dateInitial="Wed Mar 10 2021 00:00:00 GMT-0500"; 
  //dateFinal:Date= new Date();
  lineChartDataCompra: number[]=[];
  lineChartDataVenta: number[]=[];
  chartReady=false;

  @ViewChild(BaseChartDirective, { static: true }) chart: BaseChartDirective;

  constructor(private service: ReportesService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.service.FlujoVentasMensuales().subscribe(
      data => {
       
        for(let item of data){
          this.lineChartDataVenta.push(item.total);
          this.lineChartLabels.push(item.mes_Descripcion);          
        }
        this.service.FlujoComprasMensuales().subscribe(
          data => {
            for(let item of data){
              this.lineChartDataCompra.push(item.total);                     
            }  
            this.lineChartData= [
              { data:this.lineChartDataCompra , label: 'Compra' },
              { data:this.lineChartDataVenta , label: 'Venta' },          
            ];
            console.log(this.lineChartData); 
            this.chartReady=true;
          }, 
          error=> console.error(error));
        
      }, error => console.error(error)
  );
  }

  clear(): void {
    this.lineChartData = [];
    this.lineChartDataCompra=[];
    this.lineChartDataVenta=[];
    this.lineChartLabels=[];
    this.chartReady=false;
  }
  formGroup = this.fb.group({
    fechaInicio:[''],
    fechaFin:[''],
  });
  dataFilter()
  {
    this.clear();       
    let interval:  IInterval = Object.assign({}, this.formGroup.value);
    this.service.FlujoVentasMensualesInterval(interval).subscribe(
      data => {
        for(let item of data){
          this.lineChartDataVenta.push(item.total);
          this.lineChartLabels.push(item.mes_Descripcion);          
        }
        this.service.FlujoComprasMensualesInterval(interval).subscribe(
          data => {
            for(let item of data){
              this.lineChartDataCompra.push(item.total);                     
            }  
            this.lineChartData= [
              { data:this.lineChartDataCompra , label: 'Compra' },
              { data:this.lineChartDataVenta , label: 'Venta' },          
            ];
            this.chartReady=true;
          }, 
          error=> console.error(error));
        
      }, error => console.error(error)
    );
  } 
  get fechaInicio() {
    return this.formGroup.get('fechaInicio');
  }
  get fechaFin() {
    return this.formGroup.get('fechaFin');
  }


}
