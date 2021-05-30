import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parametros',
  templateUrl: './parametros.component.html',
  styleUrls: ['./parametros.component.css']
})
export class ParametrosComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export interface IParametros {
  id:number,
  agrupacion: string,
  valorNumerico: number,
  valorTxt: string,
  descripcion: string
}
