import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { INomina } from '../nomina.component';
import { NominaService } from '../nomina.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IEmpleado } from 'src/app/empleados/empleados.component';
import { EmpleadosService } from 'src/app/empleados/empleados.service';
import { AlertService } from '../../notifications/_services';


@Component({
  selector: 'app-nomina-form',
  templateUrl: './nomina-form.component.html',
  styleUrls: ['./nomina-form.component.css']
})
export class NominaFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private nominaService: NominaService,
    private empleadoService: EmpleadosService, private router: Router, private activatedRoute: ActivatedRoute,
     private alertService: AlertService) { }

  modoEdicion: boolean = false;
  empleadoId: number;
  nominaId: string;

  formGroup = this.fb.group({
    idEmpleado: ['', [Validators.required]],
    diasTrabajados: ['', [Validators.required]],
    horaExtraDiurna: ['', [Validators.required]],
    horaExtraDiurnaFestivo: ['', [Validators.required]],
    horaExtraNocturna: ['', [Validators.required]],
    horaExtraNocturnaFestivo: ['', [Validators.required]],
    salarioBase: ['', [Validators.required]],
    comisiones: ['', []]
  });
  empleados: IEmpleado[];
  ngOnInit() {
    this.empleadoService.getEmpleados() //ACA EVENTUALMENTE SOLO DEBE LLAMAR UNA FUNCION QUE RETORNE LAS ID DE LOS EMPLEADOS SIN USUARIOS
      .subscribe(empleados => this.empleados = empleados,
        error => this.alertService.error(error.message));

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.empleadoId = params["id"];
      this.nominaId = params["idN"];
      this.nominaService.getNomina(this.nominaId, this.empleadoId).subscribe(nomina => this.cargarFormulario(nomina),
        error => this.alertService.error(error.message));
    });
  }

  cargarFormulario(nomina: INomina) {
    this.formGroup.patchValue({
      idEmpleado: nomina.idEmpleado,
      diasTrabajados: nomina.diasTrabajados,
      horaExtraDiurna: nomina.horaExtraDiurna,
      horaExtraDiurnaFestivo: nomina.horaExtraDiurnaFestivo,
      horaExtraNocturna: nomina.horaExtraNocturna,
      horaExtraNocturnaFestivo: nomina.horaExtraNocturnaFestivo,
      salarioBase: nomina.salarioBase,
      comisiones: nomina.comisiones
    });
  }

  save() {
    let nomina: INomina = Object.assign({}, this.formGroup.value);

    if (this.modoEdicion) {
      // edita un usuario
      nomina.idEmpleado = this.empleadoId;
      this.nominaService.updateNomina(nomina)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea un usuario
      this.nominaService.createNomina(nomina)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/nominas"]);
    this.alertService.success("Guardado Exitoso");
  }

  get idEmpleado() {
    return this.formGroup.get('idEmpleado');
  }
  get diasTrabajados() {
    return this.formGroup.get('diasTrabajados');
  }
  get horaExtraDiurna() {
    return this.formGroup.get('horaExtraDiurna');
  }
  get horaExtraDiurnaFestivo() {
    return this.formGroup.get('horaExtraDiurnaFestivo');
  }
  get horaExtraNocturna() {
    return this.formGroup.get('horaExtraNocturna');
  }
  get horaExtraNocturnaFestivo() {
    return this.formGroup.get('horaExtraNocturnaFestivo');
  }
  get salarioBase() {
    return this.formGroup.get('salarioBase');
  }
  get comisiones() {
    return this.formGroup.get('comisiones');
  }

}
