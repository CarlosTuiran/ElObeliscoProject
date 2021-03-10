import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-dialogo-crear-factura',
  templateUrl: './dialogo-crear-factura.component.html',
  styleUrls: ['./dialogo-crear-factura.component.css']
})
export class DialogoCrearFacturaComponent implements OnInit {

  subTotal=0;
    constructor(public dialogRef: MatDialogRef<DialogoCrearFacturaComponent>,
        @Inject(MAT_DIALOG_DATA)  data) {
          this.subTotal=data.subTotal;
         }

  ngOnInit() {
  }

}
