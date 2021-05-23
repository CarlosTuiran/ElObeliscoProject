import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { IProducto, IProducto2 } from '../productos.component';
import { ProductosService } from '../productos.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-table-productos',
  templateUrl: './table-productos.component.html',
  styleUrls: ['./table-productos.component.css']
})
export class TableProductosComponent implements OnInit {

  productos!:IProducto2[];  
  displayedColumns: string[] = [
    'referencia',
    'descripcion',
    'formatoVenta',
    'idMarca',
    'idCategoria',
    'idProveedor',
    'fabrica',
    'costo',
    'precioVenta',
    'iva',
    'fechaRegistro',
    'options'];
  dataSource =new MatTableDataSource<IProducto2>(this.productos);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private productosService: ProductosService, private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService){}
  
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

  Eliminar(referencia: string) {
    this.productosService.deleteProducto(referencia).
      subscribe(referencia => this.onDeleteSuccess(),
        error => console.error(error))
  }

  onDeleteSuccess() {
    this.router.navigate(["/productos"]);
    this.alertService.success("Eliminado exitoso");
  }
}
