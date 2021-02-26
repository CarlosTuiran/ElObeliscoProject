import { Component, OnInit } from '@angular/core';
import { ProductosService } from './productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {

  productos: IProducto[];
  dtOptions: DataTables.Settings = {};

  constructor(private productosService: ProductosService) { }

  ngOnInit() {
    this.productosService.getProductos()
      .subscribe(productos => this.productos = productos,
        error => console.error(error));
  }
}

export interface IProducto {
  referencia: string,
  descripcion: string,
  formatoVenta: string,
  marca: string,
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
