import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { MarcaService } from '../../marca/marca.service';
import { ICategoria } from '../categoria.component';
import { CategoriaService } from '../categoria.service';

@Component({
  selector: 'app-dialogo-categoria',
  templateUrl: './dialogo-categoria.component.html',
  styleUrls: ['./dialogo-categoria.component.css']
})
export class DialogoCategoriaComponent implements OnInit {

  constructor(private fb: FormBuilder, private categoriaService: CategoriaService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private dialogRef: MatDialogRef<DialogoCategoriaComponent>) { }


  public idCategoria: number;

  formGroup = this.fb.group({
    nombre: ['', [Validators.required]]
  });

  ngOnInit() {
    if (this.idCategoria != null) {
      this.categoriaService.getCategoria(this.idCategoria).subscribe(categoria => this.cargarFormulario(categoria),
        error => this.alertService.error(error.error));
    }
  }
  cargarFormulario(categoria: ICategoria) {
    this.formGroup.patchValue({
      nombre: categoria.nombre
    });
  }

  save() {
    let categoria: ICategoria = Object.assign({}, this.formGroup.value);
    if (this.idCategoria != null) {
      // edita
      categoria.id = this.idCategoria;
      this.categoriaService.updateCategoria(categoria)
        .subscribe(marca => this.onSaveSuccess(),
          error => this.alertService.error(error.error));
      this.dialogRef.close();
    } else {
      // crea
      this.categoriaService.createCategoria(categoria)
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
