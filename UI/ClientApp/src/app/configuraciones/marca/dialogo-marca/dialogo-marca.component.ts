import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IMarca } from '../marca.component';
import { MarcaService } from '../marca.service';

@Component({
  selector: 'app-dialogo-marca',
  templateUrl: './dialogo-marca.component.html',
  styleUrls: ['./dialogo-marca.component.css']
})
export class DialogoMarcaComponent implements OnInit {

  constructor(private fb: FormBuilder, private marcaService: MarcaService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private dialogRef: MatDialogRef<DialogoMarcaComponent>) { }


  public idMarca: number;

  formGroup = this.fb.group({
    nombre: ['', [Validators.required]]
  });

  ngOnInit() {
    if (this.idMarca != null) {
      this.marcaService.getMarca(this.idMarca).subscribe(marca => this.cargarFormulario(marca),
        error => this.alertService.error(error.error));
    }
  }

  cargarFormulario(marca: IMarca) {
    this.formGroup.patchValue({
      nombre: marca.nombre
    });
  }

  save() {
    let marca: IMarca = Object.assign({}, this.formGroup.value);
    console.table(marca);
    if (this.idMarca != null) {
      // edita
      marca.id = this.idMarca;
      this.marcaService.updateMarca(marca)
        .subscribe(marca => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
      this.dialogRef.close();
    } else {
      // crea
      this.marcaService.createMarca(marca)
        .subscribe(marca => this.onSaveSuccess(),
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
