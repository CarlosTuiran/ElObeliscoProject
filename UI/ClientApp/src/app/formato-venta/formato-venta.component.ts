import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-formato-venta',
  templateUrl: './formato-venta.component.html',
  styleUrls: ['./formato-venta.component.css']
})
export class FormatoVentaComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export interface IFormatoVenta{
  id:number,
  nombre:string,
  abreviacion:string,
  metrica:string,
  factorConversion:number
}
