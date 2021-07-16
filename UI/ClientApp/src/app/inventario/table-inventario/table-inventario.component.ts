import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { CantidadMinimaAlertService } from '../../notifications/cantidad-minima-alert/cantidad-minima-alert.service';
import { IProducto } from '../../productos/productos.component';
import { IInventario } from '../inventario.component';
import { InventarioService } from '../inventario.service';

@Component({
  selector: 'app-table-inventario',
  templateUrl: './table-inventario.component.html',
  styleUrls: ['./table-inventario.component.css']
})
export class TableInventarioComponent implements OnInit {

  inventarios!: IInventario[];
  productosAlerts: IProducto[];
  displayedColumns: string[] = [
    'referencia',
    'descripcion',
    'formatoVenta',
    'cantidad',
    'precioVenta',
    'options'];
  dataSource = new MatTableDataSource<IInventario>(this.inventarios);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private inventarioService: InventarioService, private cantidadMinimaAlertService: CantidadMinimaAlertService) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.inventarioService.getInventarios()
      .subscribe(inventarios => this.dataSource.data = inventarios,
        error => console.error(error));
    this.cantidadMinimaAlertService.getAlerts()
      .subscribe(productos => this.productosAlerts=productos,
      error => console.error(error));    
  }
  //compara la lista de productos con alerta
  checkProductos(referencia: string): boolean{
    let referenciaFinder = this.productosAlerts.find(t => t.referencia == referencia);//busca si existe tal referencia
    if(referenciaFinder){
      return true;
    }else{
      return false
    }
  }
}
