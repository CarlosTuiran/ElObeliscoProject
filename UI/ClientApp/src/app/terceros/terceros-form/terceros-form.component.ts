import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ITercero } from '../terceros.component';
import { TercerosService } from '../terceros.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-terceros-form',
  templateUrl: './terceros-form.component.html',
  styleUrls: ['./terceros-form.component.css']
})
export class TercerosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private tercerosService: TercerosService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  terceroId: string;

  formGroup = this.fb.group({
    nit: ['', [Validators.required]],
    nombre: ['', [Validators.required]],
    apellidos: ['', [Validators.required]],
    tipoTercero: ['', [Validators.required]],
    celular: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
    correo: ['', [Validators.required]],
    direccion: ['', [Validators.required]],
    descripcion: ['', [Validators.required]]
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.terceroId = params["id"];
      this.tercerosService.getTercero(this.terceroId).subscribe(tercero => this.cargarFormulario(tercero),
        error => console.error(error));
    });
  }
  cargarFormulario(tercero: ITercero) {
    this.formGroup.patchValue({
      nit: tercero.nit,
      nombre: tercero.nombre,
      apellidos: tercero.apellidos,
      tipoTercero: tercero.tipoTercero,
      celular: tercero.celular,
      correo: tercero.correo,
      direccion: tercero.direccion,
      descripcion: tercero.descripcion
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
          error => console.error(error));
    } else {
      // crea
      this.tercerosService.createTerceros(tercero)
        .subscribe(tercero => this.onSaveSuccess(),
          error => console.error(error));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/terceros"]);
  }

  get nit() {
    return this.formGroup.get('nit');
  }
  get nombre() {
    return this.formGroup.get('nombre');
  }
  get apellidos() {
    return this.formGroup.get('apellidos');
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
  get descripcion() {
    return this.formGroup.get('descripcion');
  }
}
