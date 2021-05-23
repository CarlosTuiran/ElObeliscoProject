import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IImpuesto } from '../impuesto.component';
import { ImpuestoService } from '../impuesto.service';

@Component({
  selector: 'app-dialogo-impuesto',
  templateUrl: './dialogo-impuesto.component.html',
  styleUrls: ['./dialogo-impuesto.component.css']
})
export class DialogoImpuestoComponent implements OnInit {

  constructor(private fb: FormBuilder, private impuestoService: ImpuestoService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private dialogRef: MatDialogRef<DialogoImpuestoComponent>) { }


  public idImpuesto: number;

  formGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    tarifa: ['', [Validators.required]],
    tipo: ['', [Validators.required]]
  });

  ngOnInit() {
    if (this.idImpuesto != null) {
      this.impuestoService.getImpuesto(this.idImpuesto).subscribe(impuesto => this.cargarFormulario(impuesto),
        error => this.alertService.error(error.error));
    }
  }

  cargarFormulario(impuesto: IImpuesto) {
    this.formGroup.patchValue({
      nombre: impuesto.nombre,
      tarifa: impuesto.tarifa,
      tipo: impuesto.tipo
    });
  }

  save() {
    let impuesto: IImpuesto = Object.assign({}, this.formGroup.value);
    if (this.idImpuesto != null) {
      // edita
      impuesto.id = this.idImpuesto;
      this.impuestoService.updateImpuesto(impuesto)
        .subscribe(impuesto => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
      this.dialogRef.close();
    } else {
      // crea
      this.impuestoService.createImpuesto(impuesto)
        .subscribe(impuesto => this.onSaveSuccess(),
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
  get tarifa() {
    return this.formGroup.get('tarifa');
  }
  get tipo() {
    return this.formGroup.get('tipo');
  }
}
