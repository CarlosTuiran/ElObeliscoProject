import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { Router } from '@angular/router';
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
  constructor(private facturasService: FacturasService,
     private alertService: AlertService,  private dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    this.facturasService.getFacturas()
      .subscribe(factura => this.facturas = factura,
        error =>this.alertService.error(error.message)
      );
  }


  openDialog() {
    const dialogRef = this.dialog.open(DialogoTipoTerceroComponent, {
      width: '25%',
      height: '15%'
      
    });

    dialogRef.afterClosed().subscribe(result => {
      this.dialogRta = result; console.log(result);
      this.router.navigate(["/facturas-crear/" + result]);
    }
    );
  }
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
   estadoFactura: string,
   dFacturas: IDFactura[] 

}
export interface IDFactura{
  idDfactura:number,
  mfacturaId:number,
  referencia :string,
  promocionId :number,
  bodega :string,
  cantidad:number,
  precioUnitario:number
}
