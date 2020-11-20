import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType } from 'chart.js';
import { Label, SingleDataSet } from 'ng2-charts';
import { IPruebaCovidReport } from '../pruebas-sin-vs.component';
import { PruebasSinVSService } from '../pruebas-sin-vs.service';

@Component({
  selector: 'app-pruebapiechart',
  templateUrl: './pruebapiechart.component.html',
  styleUrls: ['./pruebapiechart.component.css']
})
export class PruebapiechartComponent implements OnInit {

  public pieChartOptions: ChartOptions = {
    responsive: true,
  };
  public pieChartLabels: Label[] = ['Confirmados', 'Recuperados', 'Activos', 'Defunciones'];
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
        'rgba(136,136,136,0.9)'
      ]
    }
  ];

  countries: IPruebaCovidReport[] = [];
  country: IPruebaCovidReport = null;

  constructor(private service: PruebasSinVSService) {  }

  ngOnInit(): void {
    this.getCountries();
  }

  loadData(event: any): void {
    if (this.country) {
      this.clear();
      this.service.fromCountry(this.country.country).subscribe(
        data => {
          const last = data.pop();
          this.pieChartData[0] = last.cases;
          this.pieChartData[1] = last.recovered;
          this.pieChartData[2] = last.active;
          this.pieChartData[3] = last.deaths;
        },error => console.error(error)     
      );
    }
  }

  getCountries(): void {
    this.service.pruebaCovidReports().subscribe(
      datos => this.countries = datos as IPruebaCovidReport[],
      error => console.error(error));     
    
  }

  clear(): void {
    this.pieChartData = [];
  }

}
