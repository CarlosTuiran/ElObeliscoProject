import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bodegas',
  templateUrl: './bodegas.component.html',
  styleUrls: ['./bodegas.component.css']
})
export class BodegasComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export interface IBodega{
  bodegaId:number,
  nombre:string
}
