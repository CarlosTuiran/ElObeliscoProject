import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { DialogoMarcaComponent } from './dialogo-marca/dialogo-marca.component';

@Component({
  selector: 'app-marca',
  templateUrl: './marca.component.html',
  styleUrls: ['./marca.component.css']
})
export class MarcaComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog() {
    const detallesVista = this.dialog.open(DialogoMarcaComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
  }
}
export interface IMarca{
  id: number,
  nombre: string
}
