import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ITercero } from '../terceros.component';
import { TercerosService } from '../terceros.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../../notifications/_services';

@Component({
  selector: 'app-terceros-form',
  templateUrl: './terceros-form.component.html',
  styleUrls: ['./terceros-form.component.css']
})
export class TercerosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private tercerosService: TercerosService,
    private router: Router, private activatedRoute: ActivatedRoute, 
    private alertService: AlertService) { }

  modoEdicion: boolean = false;
  terceroId: string;

  formGroup = this.fb.group({
    identificacion: ['', [Validators.required]],
    tipoId:['', [Validators.required]],
    nombre: ['', [Validators.required]],
    apellido: [''],
    tipoTercero: ['', [Validators.required]],
    tipoPersona:['', [Validators.required]],
    actividadEconomica:['', [Validators.required]],
    responsabilidadFiscal:['', [Validators.required]],
    responsableIva:['', [Validators.required]],
    autoRetenedor:['', [Validators.required]],
    extranjero:['', [Validators.required]],
    celular: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
    correo: ['', [Validators.required]],
    direccion: ['', [Validators.required]],
    ciudad: ['', [Validators.required]],
    telefono: ['', [Validators.required]],
    descripcion: ['', [Validators.required]],
    fechaCumple: ['', [Validators.required]]
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.terceroId = params["id"];
      this.tercerosService.getTercero(this.terceroId).subscribe(tercero => this.cargarFormulario(tercero),
        error => this.alertService.error(error.message));
    });
  }
  cargarFormulario(tercero: ITercero) {
    this.formGroup.patchValue({
      identificacion: tercero.identificacion,
      tipoId:tercero. tipoId,
      nombre: tercero.nombre,
      apellido: tercero.apellido,
      tipoTercero: tercero.tipoTercero,
      tipoPersona:tercero.tipoPersona,
      actividadEconomica:tercero.actividadEconomica,
      responsabilidadFiscal:tercero.responsabilidadFiscal,
      responsableIva:tercero.responsableIva,
      autoRetenedor:tercero.autoRetenedor,
      extranjero:tercero.extranjero,
      celular: tercero.celular,
      telefono:tercero.telefono,
      correo: tercero.correo,
      ciudad:tercero.ciudad,
      direccion: tercero.direccion,
      descripcion: tercero.descripcion,
      fechaCumple: tercero.fechaCumple
    });
  }

  save() {
    let tercero: ITercero = Object.assign({}, this.formGroup.value);
    console.table(tercero); //ver usuario por consola
    if (this.modoEdicion) {
      // edita
      tercero.identificacion = this.terceroId;
      this.tercerosService.updateTercero(tercero)
        .subscribe(tercero => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea
      this.tercerosService.createTercero(tercero)
        .subscribe(tercero => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/terceros"]);
    this.alertService.success("Guardado Exitoso");
  }
  
  get identificacion() {
    return this.formGroup.get('identificacion');
  }
  get tipoId() {
    return this.formGroup.get('tipoId');
  }
  get tipoPersona() {
    return this.formGroup.get('tipoPersona');
  }
  get  actividadEconomica() {
    return this.formGroup.get('actividadEconomica');
  }
  get responsabilidadFiscal() {
    return this.formGroup.get('responsabilidadFiscal');
  }
  get responsableIva() {
    return this.formGroup.get('responsableIva');
  }
  get autoRetenedor() {
    return this.formGroup.get('autoRetenedor');
  }
  get extranjero() {
    return this.formGroup.get('extranjero');
  }
  get nombre() {
    return this.formGroup.get('nombre');
  }
  get apellido() {
    return this.formGroup.get('apellido');
  }
  get tipoTercero() {
    return this.formGroup.get('tipoTercero');
  }
  get celular() {
    return this.formGroup.get('celular');
  }
  get correo() {
    return this.formGroup.get('correo');
  }
  get direccion() {
    return this.formGroup.get('direccion');
  }
  get ciudad() {
    return this.formGroup.get('ciudad');
  }
  get telefono() {
    return this.formGroup.get('telefono');
  }
  get descripcion() {
    return this.formGroup.get('descripcion');
  }
  get fechaCumple() {
    return this.formGroup.get('fechaCumple');
  }
}
