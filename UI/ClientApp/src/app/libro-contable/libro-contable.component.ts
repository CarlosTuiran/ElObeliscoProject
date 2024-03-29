import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-libro-contable',
  templateUrl: './libro-contable.component.html',
  styleUrls: ['./libro-contable.component.css']
})
export class LibroContableComponent implements OnInit {

  constructor(@Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
  }
  printPDF(){
    var URL = this.baseUrl+"LibroContablePDF"; 
    window.open(URL, '_blank');
  }
  balanceGeneralPDF() {
    var URL = this.baseUrl + "BalanceGeneral";
    window.open(URL, '_blank');
  }
}
export interface ILibroContable{
  codigo: number,
  descripcion :string,
  debe:number,          
  haber : number,
  origenId : number,
  origenTipo : string,
  fecha: Date
}

export interface ILibroContable2{
  id: number,
  codigo: number,
  descripcion :string,
  tipoMovimientoId:number,
  valor : number,
  origenId : number,
  origenTipo : string
}
