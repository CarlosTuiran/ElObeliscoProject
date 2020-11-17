import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-pruebas-sin-vs',
  templateUrl: './pruebas-sin-vs.component.html',
  styleUrls: ['./pruebas-sin-vs.component.css']
})
export class PruebasSinVSComponent implements OnInit {

  
  constructor() { }

  ngOnInit() {
    
  }

}

export interface IPruebaCovidReport{
country:string
}
