import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-dialogo-tipo-tercero',
  templateUrl: './dialogo-tipo-tercero.component.html',
  styleUrls: ['./dialogo-tipo-tercero.component.css']
})
export class DialogoTipoTerceroComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<DialogoTipoTerceroComponent>) { }

  ngOnInit() {
  }

}
