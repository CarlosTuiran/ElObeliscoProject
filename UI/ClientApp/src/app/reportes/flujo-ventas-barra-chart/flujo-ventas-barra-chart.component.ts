import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { Label } from 'ng2-charts';
import { IInterval } from '../reportes.component';
import { ReportesService } from '../reportes.service';


@Component({
  selector: 'app-flujo-ventas-barra-chart',
  templateUrl: './flujo-ventas-barra-chart.component.html',
  styleUrls: ['./flujo-ventas-barra-chart.component.css']
})
export class FlujoVentasBarraChartComponent implements OnInit {
  public barChartOptions: ChartOptions = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      }
    }
  };
  public barChartLabels: Label[] = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
 

  public barChartData: ChartDataSets[];

  barChartDataCompra: number[]=[];
  barChartDataVenta: number[]=[];
  chartReady=false;

  constructor(private service: ReportesService, private fb: FormBuilder) { }

  ngOnInit() {
    this.service.FlujoVentasMensuales().subscribe(
      data => {
       
        for(let item of data){
          this.barChartDataVenta.push(item.total);
          this.barChartLabels.push(item.mes_Descripcion);          
        }
        this.service.FlujoComprasMensuales().subscribe(
          data => {
            for(let item of data){
              this.barChartDataCompra.push(item.total);                     
            }  
            this.barChartData= [
              { data:this.barChartDataCompra , label: 'Compra' },
              { data:this.barChartDataVenta , label: 'Venta' },          
            ];
            console.log(this.barChartData); 
            this.chartReady=true;
          }, 
          error=> console.error(error));
        
      }, error => console.error(error)
  );
  }
clear(): void {
    this.barChartData = [];
    this.barChartDataCompra=[];
    this.barChartDataVenta=[];
    this.barChartLabels=[];
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
          this.barChartDataVenta.push(item.total);
          this.barChartLabels.push(item.mes_Descripcion);          
        }
        this.service.FlujoComprasMensualesInterval(interval).subscribe(
          data => {
            for(let item of data){
              this.barChartDataCompra.push(item.total);                     
            }  
            this.barChartData= [
              { data:this.barChartDataCompra , label: 'Compra' },
              { data:this.barChartDataVenta , label: 'Venta' },          
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
