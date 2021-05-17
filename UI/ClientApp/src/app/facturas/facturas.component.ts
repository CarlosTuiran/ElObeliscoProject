import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
import { IFormatoVenta } from '../formato-venta/formato-venta.component';
import { AlertService } from '../notifications/_services';
import {FacturasService} from './facturas.service';
import { DialogoTipoTerceroComponent } from './table-facturas/dialogo-tipo-tercero/dialogo-tipo-tercero.component';

@Component({
  selector: 'app-facturas',
  templateUrl: './facturas.component.html',
  styleUrls: ['./facturas.component.css']
})
export class FacturasComponent implements OnInit {
  isAdmin = false;
  facturas:IMFactura[];
  dialogRta = "";
    TipoMov: string;
  constructor(private facturasService: FacturasService,
    private alertService: AlertService, private dialog: MatDialog, private router: Router,
    private activatedRoute: ActivatedRoute  ) { }

  ngOnInit() {
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    if (segments[0].toString() == 'facturasVenta') {
      this.TipoMov = "Venta";
    } else {
      this.TipoMov = "Compra";
    }

    /*this.facturasService.getFacturas()
      .subscribe(factura => this.facturas = factura,
        error =>this.alertService.error(error.message)
      );*/
  }

  /*
  openDialog() {
    const dialogRef = this.dialog.open(DialogoTipoTerceroComponent, {
      width: 'auto',
      height: 'auto'
      
    });

    dialogRef.afterClosed().subscribe(result => {
      this.dialogRta = result;
      if (result != undefined) {
        this.router.navigate(["/facturas-crear/" + result]);
      }      
    }
    );
  }*/
}

export interface IMFactura{
   idMfactura:number,
   empleadoId :number,
   tercerosId :number,
   tipoMovimientoId :number,
   tipoMovimiento:string,
   fechaPago: Date, 
   subTotal :number,
   valorDevolucion :number,
   descuento :number,
   iVA :number,
   abono :number,
   total:number,
   estadoFactura: string,
   serial:string,
   observaciones:string,
   dFacturas: IDFactura[] 

}
export interface IDFactura{
  idDfactura:number,
  mfacturaId:number,
  referencia: string,
  iVA:number,
  promocionId :number,
  bodega :string,
  cantidad:number,
  cantidadDigitada:number,
  formatoProducto:string,
  precioUnitario:number,
  precioTotal: number
}
