import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICuenta } from '../../contabilidad/cuenta/cuenta.component';
import { CuentaService } from '../../contabilidad/cuenta/cuenta.service';
import { IFormatoVenta } from '../../formato-venta/formato-venta.component';
import { FormatoVentaService } from '../../formato-venta/formato-venta.service';
import { AlertService } from '../../notifications/_services';
import { ILibroContable2 } from '../libro-contable.component';
import { LibroContableService } from '../libro-contable.service';

@Component({
  selector: 'app-form-libro-contable',
  templateUrl: './form-libro-contable.component.html',
  styleUrls: ['./form-libro-contable.component.css']
})
export class FormLibroContableComponent implements OnInit {

  constructor(
    private fb: FormBuilder, private libroContableService: LibroContableService,
    private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService, private cuentaService: CuentaService,
    private formatoVentaService: FormatoVentaService
  ) { }

  formatos: IFormatoVenta[];
  cuentas: ICuenta[];
  modoEdicion: boolean = false;
  libroContableId: number;

  formGroup = this.fb.group({
    tipoMovimientoId: ['', [Validators.required]],
    descripcion: ['', [Validators.required]],
    valor: ['', [Validators.required]],
    codigo: ['', [Validators.required]]
  });

  ngOnInit() {
    this.cuentaService.getCuentas().subscribe(cuentas => {
      this.cuentas = cuentas;
      this.formatoVentaService.getFormatosVenta().subscribe(formatos => {
        this.formatos = formatos
      });
    });

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.libroContableId = params["id"];
      this.libroContableService.getLibroEmpleado(this.libroContableId).subscribe(libroContable => this.cargarFormulario(libroContable),
        error => this.alertService.error(error.message));
    });
  }

  cargarFormulario(libroContable: ILibroContable2) {
    this.formGroup.patchValue({
      tipoMovimientoId: libroContable.tipoMovimientoId,
      descripcion: libroContable.descripcion,
      valor: libroContable.valor,
      codigo: libroContable.codigo
    });
  }

  save() {
    let libroContable: ILibroContable2 = Object.assign({}, this.formGroup.value);
    console.table(libroContable); //ver usuario por consola
    if (this.modoEdicion) {
      // edita
      libroContable.id = this.libroContableId;
      this.libroContableService.updateLibroContable(libroContable)
        .subscribe(empleado => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea
      this.libroContableService.createLibroContable(libroContable)
        .subscribe(empleado => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/libroContable"]);
    this.alertService.success("Guardado Exitoso");
  }

  get tipoMovimientoId() {
    return this.formGroup.get('tipoMovimientoId');
  }
  get descripcion() {
    return this.formGroup.get('descripcion');
  }
  get valor() {
    return this.formGroup.get('valor');
  }
  get codigo() {
    return this.formGroup.get('codigo');
  }

}
