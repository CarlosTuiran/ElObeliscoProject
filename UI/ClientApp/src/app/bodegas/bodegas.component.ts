import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogoBodegasComponent } from './dialogo-bodegas/dialogo-bodegas.component';

@Component({
  selector: 'app-bodegas',
  templateUrl: './bodegas.component.html',
  styleUrls: ['./bodegas.component.css']
})
export class BodegasComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog() {
    const detallesVista = this.dialog.open(DialogoBodegasComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
  }
}
export interface IBodega{
  id:number,
  nombre:string
}
