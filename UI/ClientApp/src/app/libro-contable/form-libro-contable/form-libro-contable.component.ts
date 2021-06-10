import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ReplaySubject } from 'rxjs';
import { ICuenta } from '../../contabilidad/cuenta/cuenta.component';
import { CuentaService } from '../../contabilidad/cuenta/cuenta.service';
import { ITipoMovimiento } from '../../facturas/tipo-movimentos/tipo-movimentos.component';
import { TipoMovimientosService } from '../../facturas/tipo-movimentos/tipo-movimientos.service';
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
    private tipoMovimientoService: TipoMovimientosService
  ) { }

  tiposMovimiento: ITipoMovimiento[];
  modoEdicion: boolean = false;
  libroContableId: number;

  formGroup = this.fb.group({
    tipoMovimientoId: ['', [Validators.required]],
    descripcion: ['', [Validators.required]],
    valor: ['', [Validators.required]],
    codigo: ['', [Validators.required]]
  });

  ngOnInit() {
    this.tipoMovimientoService.getTipoMovimientos().subscribe(tiposMovimiento => {
      this.tiposMovimiento = tiposMovimiento
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

  receiveMessageCuenta($event) {
    this.codigo.setValue($event.id);
  }

}
