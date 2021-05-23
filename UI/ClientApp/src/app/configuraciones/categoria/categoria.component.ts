import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogoCategoriaComponent } from './dialogo-categoria/dialogo-categoria.component';

@Component({
  selector: 'app-categoria',
  templateUrl: './categoria.component.html',
  styleUrls: ['./categoria.component.css']
})
export class CategoriaComponent implements OnInit {

  constructor(private dialog: MatDialog) { }

  ngOnInit() {
  }

  openDialog() {
    const detallesVista = this.dialog.open(DialogoCategoriaComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
  }

}
export interface ICategoria {
  id: number,
  nombre: string
}
