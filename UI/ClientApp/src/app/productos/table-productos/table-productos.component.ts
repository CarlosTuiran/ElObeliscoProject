import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { IProducto } from '../productos.component';
import { ProductosService } from '../productos.service';

@Component({
  selector: 'app-table-productos',
  templateUrl: './table-productos.component.html',
  styleUrls: ['./table-productos.component.css']
})
export class TableProductosComponent implements OnInit {

  productos!:IProducto[];  
  displayedColumns: string[] = [
    'referencia',
    'descripcion',
    'formatoVenta',
    'marca',
    'fabrica',
    'costo',
    'precioVenta',
    'iva',
    'fechaRegistro'];
  dataSource =new MatTableDataSource<IProducto>(this.productos);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private productosService: ProductosService){}
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.productosService.getProductos()
    .subscribe(productos => this.dataSource.data = productos,
      error => console.error(error));

  }
}
