import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IBodega } from '../bodegas.component';
import { BodegasService } from '../bodegas.service';

@Component({
  selector: 'app-dialogo-bodegas',
  templateUrl: './dialogo-bodegas.component.html',
  styleUrls: ['./dialogo-bodegas.component.css']
})
export class DialogoBodegasComponent implements OnInit {

  constructor(private fb: FormBuilder, private bodegasService: BodegasService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private dialogRef: MatDialogRef<DialogoBodegasComponent>) { }

  public idBodega: number;

  formGroup = this.fb.group({
    nombre: ['', [Validators.required]]
  });

  ngOnInit() {
    if (this.idBodega != null) {
      this.bodegasService.getBodega(this.idBodega).subscribe(bodega => this.cargarFormulario(bodega),
        error => this.alertService.error(error.error));
    }
  }
  cargarFormulario(bodega: IBodega) {
    this.formGroup.patchValue({
      nombre: bodega.nombre
    });
  }

  save() {
    let bodega: IBodega = Object.assign({}, this.formGroup.value);
    if (this.idBodega != null) {
      // edita
      bodega.id = this.idBodega;
      this.bodegasService.updateBodega(bodega)
        .subscribe(() => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
      this.dialogRef.close();
    } else {
      // crea
      this.bodegasService.createBodega(bodega)
        .subscribe(() => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
      this.dialogRef.close();
    }
  }
  onSaveSuccess() {
    this.alertService.success("Guardado Exitoso");
  }

  get nombre() {
    return this.formGroup.get('nombre');
  }

}
