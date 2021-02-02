import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { IMFactura } from '../facturas.component';
import { FacturasService } from '../facturas.service';

@Component({
  selector: 'app-table-facturas',
  templateUrl: './table-facturas.component.html',
  styleUrls: ['./table-facturas.component.css']
})
export class TableFacturasComponent implements OnInit {
  isAdmin = false;
  constructor(private facturasService: FacturasService) { }
  facturas!:IMFactura[];  
  displayedColumns: string[] = [
    'empleadoId',
    'tercerosId',
    'tipoMovimientoId',
    'fechaPago',
    'subTotal',
    'valorDevolucion',
    'descuento',
    'iVA',
    'abono',
    'estadoFactura',
    'options'
];
  dataSource =new MatTableDataSource<IMFactura>(this.facturas);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  

  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.facturasService.getFacturas()
    .subscribe(facturas => this.dataSource.data = facturas,
      error => console.error(error));

  }


}
