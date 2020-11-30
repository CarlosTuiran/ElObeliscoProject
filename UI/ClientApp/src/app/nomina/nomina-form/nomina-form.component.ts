import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { INomina } from '../nomina.component';
import { NominaService } from '../nomina.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IEmpleado } from 'src/app/empleados/empleados.component';
import { EmpleadosService } from 'src/app/empleados/empleados.service';

@Component({
  selector: 'app-nomina-form',
  templateUrl: './nomina-form.component.html',
  styleUrls: ['./nomina-form.component.css']
})
export class NominaFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private nominaService: NominaService,
    private empleadoService: EmpleadosService, private router: Router, private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  empleadoId: number;
  nominaId: string;

  formGroup = this.fb.group({
    idEmpleado: ['', [Validators.required]],
    diasTrabajados: ['', [Validators.required]],
    horasExtras: ['', [Validators.required]],
    salarioBase: ['', [Validators.required]],
    subTransporte: ['', [Validators.required]]
  });
  empleados: IEmpleado[];
  ngOnInit() {
    this.empleadoService.getEmpleados() //ACA EVENTUALMENTE SOLO DEBE LLAMAR UNA FUNCION QUE RETORNE LAS ID DE LOS EMPLEADOS SIN USUARIOS
      .subscribe(empleados => this.empleados = empleados,
        error => console.error(error));

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.empleadoId = params["id"];
      this.nominaId = params["idN"];
      this.nominaService.getNomina(this.nominaId, this.empleadoId).subscribe(nomina => this.cargarFormulario(nomina),
        error => console.error(error));
    });
  }

  cargarFormulario(nomina: INomina) {
    this.formGroup.patchValue({
      diasTrabajados: nomina.diasTrabajados,
      horasExtras: nomina.horasExtras,
      salarioBase: nomina.salarioBase,
      subTransporte: nomina.subTransporte
    });
  }

  save() {
    let nomina: INomina = Object.assign({}, this.formGroup.value);

    if (this.modoEdicion) {
      // edita un usuario
      nomina.idEmpleado = this.empleadoId;
      this.nominaService.updateNomina(nomina)
        .subscribe(usuario => this.onSaveSuccess(),
          error => console.error(error));
    } else {
      // crea un usuario
      this.nominaService.createNomina(nomina)
        .subscribe(usuario => this.onSaveSuccess(),
          error => console.error(error));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/nominas"]);
  }

  get idEmpleado() {
    return this.formGroup.get('idEmpleado');
  }
  get diasTrabajados() {
    return this.formGroup.get('diasTrabajados');
  }
  get horasExtras() {
    return this.formGroup.get('horasExtras');
  }
  get salarioBase() {
    return this.formGroup.get('salarioBase');
  }
  get subTransporte() {
    return this.formGroup.get('subTransporte');
  }

}
