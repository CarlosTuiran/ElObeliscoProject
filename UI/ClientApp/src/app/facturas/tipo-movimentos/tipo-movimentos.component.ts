import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-tipo-movimentos',
  templateUrl: './tipo-movimentos.component.html',
  styleUrls: ['./tipo-movimentos.component.css']
})
export class TipoMovimentosComponent implements OnInit {
  isAdmin = false;
  constructor() { }

  ngOnInit() {
  }

}
export interface ITipoMovimiento{
  idMovimiento: number,
  nombre: string,
}
