import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog,  MatDialogRef, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { IMFactura } from '../facturas.component';
import { FacturasService } from '../facturas.service';
import { TableDetallesComponent } from '../table-detalles/table-detalles.component';
import { DialogoTipoTerceroComponent } from './dialogo-tipo-tercero/dialogo-tipo-tercero.component';

@Component({
  selector: 'app-table-facturas',
  templateUrl: './table-facturas.component.html',
  styleUrls: ['./table-facturas.component.css']
})
export class TableFacturasComponent implements OnInit {
  isAdmin = false;
  dialogRta = "";
  constructor(private facturasService: FacturasService, private dialog: MatDialog,
    private router: Router
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
  openDetalles(idMfactura: number){
      const detallesVista= this.dialog.open(TableDetallesComponent, {
      disableClose:false,
      autoFocus:true,
      width:'60%'
    });
    detallesVista.componentInstance.idMfactura=idMfactura;
    
  }
  
  openDialog() {
    const dialogRef = this.dialog.open(DialogoTipoTerceroComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      this.dialogRta = result;
      this.router.navigate(["/facturas-crear/"+result]);
      }
    );
  }
}
