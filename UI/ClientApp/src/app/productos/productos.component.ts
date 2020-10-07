import { Component, OnInit } from '@angular/core';
import { DataTablesResponse } from '../tablas/data-tables-response';
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

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      info: true,
      language: {
        emptyTable: '',
        zeroRecords: 'No hay coincidencias',
        lengthMenu: 'Mostrar _MENU_ elementos',
        search: 'Buscar:',
        info: 'De _START_ a _END_ de _TOTAL_ elementos',
        infoEmpty: 'De 0 a 0 de 0 elementos',
        infoFiltered: '(filtrados de _MAX_ elementos totales)',
        paginate: {
          first: 'Prim.',
          last: 'Últ.',
          next: 'Sig.',
          previous: 'Ant.'
        },
      },
      ajax: (dataTablesParameters: any, callback) => {

      },
      columns: [{ data: 'doi' }, { data: 'nombre' }, { data: 'fecha_de_ingreso' }]
    }
  }
}

export interface IProducto {
  referencia: string,
  descripcion: string,
  formatoVenta: string,
  marca: string,
  costo: number,
  precioVenta: number,
  iva: number,
  fechaRegistro: Date
}
