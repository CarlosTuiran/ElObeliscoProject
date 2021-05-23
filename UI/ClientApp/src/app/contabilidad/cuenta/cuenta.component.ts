import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cuenta',
  templateUrl: './cuenta.component.html',
  styleUrls: ['./cuenta.component.css']
})
export class CuentaComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}


export interface ICuenta{
  id:number,
  nombre:string,
  clase:string,
  codigo:number,
  naturaleza:string
}
