import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { IEmpleado } from '../empleados.component';
import { EmpleadosService } from '../empleados.service';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-empleados-form',
  templateUrl: './empleados-form.component.html',
  styleUrls: ['./empleados-form.component.css']
})
export class EmpleadosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private empleadosService: EmpleadosService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  empleadoId: number;

  formGroup = this.fb.group({
    idEmpleado: ['', [Validators.required]],
    nombres: ['', [Validators.required]],
    apellidos: ['', [Validators.required]],
    cargo: ['', [Validators.required]],
    celular: ['', [Validators.required]],
    correo: ['', [Validators.required]],
    direccion: ['', [Validators.required]]
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.empleadoId = params["id"];
      this.empleadosService.getEmpleado(this.empleadoId).subscribe(empleado => this.cargarFormulario(empleado),
        error => console.error(error));
    });
  }
  cargarFormulario(empleado: IEmpleado) {
    this.formGroup.patchValue({
      idEmpleado: empleado.idEmpleado,
      nombres: empleado.nombres,
      apellidos: empleado.apellidos,
      cargo: empleado.cargo,
      celular: empleado.celular,
      correo: empleado.correo,
      direccion: empleado.direccion
    });
  }

  save() {
    let empleado: IEmpleado = Object.assign({}, this.formGroup.value);
    console.table(empleado); //ver usuario por consola
    if (this.modoEdicion) {
      // edita
      empleado.idEmpleado = this.empleadoId;
      this.empleadosService.updateEmpleado(empleado)
        .subscribe(empleado => this.onSaveSuccess(),
          error => console.error(error));
    } else {
      // crea
      this.empleadosService.createEmpleado(empleado)
        .subscribe(empleado => this.onSaveSuccess(),
          error => console.error(error));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/empleados"]);
  }

  get idEmpleado() {
    return this.formGroup.get('idEmpleado');
  }
  get nombres() {
    return this.formGroup.get('nombres');
  }
  get apellidos() {
    return this.formGroup.get('apellidos');
  }
  get cargo() {
    return this.formGroup.get('cargo');
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
}
