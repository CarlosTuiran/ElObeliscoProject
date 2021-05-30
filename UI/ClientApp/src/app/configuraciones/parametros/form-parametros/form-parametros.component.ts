import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IParametros } from '../parametros.component';
import { ParametrosService } from '../parametros.service';

@Component({
  selector: 'app-form-parametros',
  templateUrl: './form-parametros.component.html',
  styleUrls: ['./form-parametros.component.css']
})
export class FormParametrosComponent implements OnInit {

  modoEdicion: boolean = false;
  parametrosId: number;

  constructor(private parametrosService: ParametrosService, private fb: FormBuilder,
    private router: Router, private activatedRoute: ActivatedRoute, private alertService: AlertService) { }

  formGroup = this.fb.group({
    descripcion: ['', [Validators.required]],
    agrupacion: ['', [Validators.required]],
    valorTxt: ['', [Validators.required]],
    valorNumerico: ['', [Validators.required, Validators.pattern(/^\d+$/)]]
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.parametrosId = params["id"];
      this.parametrosService.getParametro(this.parametrosId).subscribe(parametros => this.cargarFormulario(parametros)),
        error => this.alertService.error(error.message);
    });
  }
  cargarFormulario(formato: IParametros) {
    this.formGroup.patchValue({
      descripcion: formato.descripcion,
      agrupacion: formato.agrupacion,
      valorTxt: formato.valorTxt,
      valorNumerico: formato.valorNumerico
    });
  }
  save() {
    let parametros: IParametros = Object.assign({}, this.formGroup.value);
    console.table(parametros); //ver usuario por consola
    if (this.modoEdicion) {
      // edita
      parametros.id = this.parametrosId
      this.parametrosService.updateParametros(parametros)
        .subscribe(parametros => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea
      this.parametrosService.createParametros(parametros)
        .subscribe(parametros => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/parametros"]);
    this.alertService.success("Guardado Exitoso");
  }

  get agrupacion() {
    return this.formGroup.get('agrupacion');
  }
  get descripcion() {
    return this.formGroup.get('descripcion');
  }
  get valorTxt() {
    return this.formGroup.get('valorTxt');
  }
  get valorNumerico() {
    return this.formGroup.get('valorNumerico');
  }
}
