import { Component, OnInit } from '@angular/core';
import { ProductosService } from './productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {

  constructor() { }

  ngOnInit() {

  }
}

export interface IProducto {
  referencia: string,
  descripcion: string,
  formatoVenta: string,
  idMarca: number,
  idCategoria: number,
  idProveedor: string,
  fabrica: string,
  costo: number,
  precioVenta: number,
  iva: number,
  fechaRegistro: Date,
  cantidadMinima: number
}

export interface IProducto2 {
  referencia: string,
  descripcion: string,
  formatoVenta: string,
  idMarca: string,
  idCategoria: string,
  idProveedor: string,
  fabrica: string,
  costo: number,
  precioVenta: number,
  iva: number,
  fechaRegistro: Date,
  cantidadMinima: number
}

export interface IDeleteProducto {
  referencia: string
}
