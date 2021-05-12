import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource, MatDialogRef } from '@angular/material';
import { IDFactura } from '../facturas.component';
import { FacturasService } from '../facturas.service';

@Component({
  selector: 'app-table-detalles',
  templateUrl: './table-detalles.component.html',
  styleUrls: ['./table-detalles.component.css']
})
export class TableDetallesComponent implements OnInit {

  isAdmin = false;
  facturas!:IDFactura[];  
  public idMfactura: number;  
  displayedColumns: string[] = [
    'empleadoId',
    'tercerosId' ,
    'referencia' ,
    'idPromocion' ,
    'bodega',
    'cantidadDigitada',
    'precioUnitario',
    'iva',
    'precioTotal',
    'fechaFactura'
  ];
  dataSource =new MatTableDataSource<IDFactura>(this.facturas);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  
  constructor(private facturasService: FacturasService,
    private dialogRef:MatDialogRef<TableDetallesComponent>) { }
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.facturasService.getDFacturas(this.idMfactura)
    .subscribe(facturas => this.dataSource.data = facturas,
      error => console.error(error));

  }
  close(){
    this.dialogRef.close();
  }

}
