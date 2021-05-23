import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogoImpuestoComponent } from './dialogo-impuesto/dialogo-impuesto.component';

@Component({
  selector: 'app-impuesto',
  templateUrl: './impuesto.component.html',
  styleUrls: ['./impuesto.component.css']
})
export class ImpuestoComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }
  openDialog() {
    const detallesVista = this.dialog.open(DialogoImpuestoComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
  }
}

export interface IImpuesto {
  id: number,
  nombre: string,
  tarifa: number,
  tipo: string,
  activo: boolean
}
