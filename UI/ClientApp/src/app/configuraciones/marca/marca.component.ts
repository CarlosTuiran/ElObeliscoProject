import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-marca',
  templateUrl: './marca.component.html',
  styleUrls: ['./marca.component.css']
})
export class MarcaComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export interface IMarca{
  id: number,
  nombre: string
}
