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
    nit: ['', [Validators.required]],
    nombre: ['', [Validators.required]],
    apellido: ['', [Validators.required]],
    tipoTercero: ['', [Validators.required]],
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
      nit: tercero.nit,
      nombre: tercero.nombre,
      apellido: tercero.apellido,
      tipoTercero: tercero.tipoTercero,
      celular: tercero.celular,
      correo: tercero.correo,
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
      tercero.nit = this.terceroId;
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

  get nit() {
    return this.formGroup.get('nit');
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
