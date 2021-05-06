import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog,  MatDialogRef, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { IMFactura } from '../facturas.component';
import { FacturasService } from '../facturas.service';
import { TableDetallesComponent } from '../table-detalles/table-detalles.component';

@Component({
  selector: 'app-table-facturas',
  templateUrl: './table-facturas.component.html',
  styleUrls: ['./table-facturas.component.css']
})
export class TableFacturasComponent implements OnInit {
  isAdmin = false;
    TipoMov: string;
  constructor(private facturasService: FacturasService,
    private router: Router, private dialog: MatDialog,
    private activatedRoute: ActivatedRoute
    ) { }
  facturas!:IMFactura[];  
  displayedColumns: string[] = [
    'mFacturaId',
    'empleadoId',
    'tercerosId',
    'tipoMovimientoId',
    'fechaPago',
    'subTotal',
    'valorDevolucion',
    'descuento',
    'iva',
    'abono',
    'total',
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
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    if (segments[0].toString() == 'facturasVenta') {
      this.TipoMov = "Venta";
    } else {
      this.TipoMov = "Compra";
    }
    this.facturasService.getFacturas(this.TipoMov)
    .subscribe(facturas => this.dataSource.data = facturas,
      error => console.error(error));
      
  }
  openDetalles(idMfactura: number){
      const detallesVista= this.dialog.open(TableDetallesComponent, {
      disableClose:false,
      autoFocus:true,
      width:'60%'
    });
    detallesVista.componentInstance.idMfactura=idMfactura;
    
  }
}
