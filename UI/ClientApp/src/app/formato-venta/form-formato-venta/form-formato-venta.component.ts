import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IFormatoVenta } from '../formato-venta.component';
import { FormatoVentaService } from '../formato-venta.service';

@Component({
  selector: 'app-form-formato-venta',
  templateUrl: './form-formato-venta.component.html',
  styleUrls: ['./form-formato-venta.component.css']
})
export class FormFormatoVentaComponent implements OnInit {

  modoEdicion: boolean = false;
  formatoVentaId: number;

  constructor(private formatoVentaService: FormatoVentaService, private fb: FormBuilder,
    private router: Router, private activatedRoute: ActivatedRoute, private alertService: AlertService) { }

  formGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    abreviacion: ['', [Validators.required]],
    metrica: ['', [Validators.required]],
    factorConversion: ['', [Validators.required, Validators.pattern(/^\d+$/)]]
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.formatoVentaId = params["id"];
      this.formatoVentaService.getFormatoVenta(this.formatoVentaId).subscribe(formatoVenta => this.cargarFormulario(formatoVenta)),
        error => this.alertService.error(error.message);
    });
  }
  cargarFormulario(formato: IFormatoVenta) {
      this.formGroup.patchValue({
        nombre: formato.nombre,
        abreviacion: formato.abreviacion,
        metrica: formato.metrica,
        factorConversion: formato.factorConversion
      });
    }
  save() {
    let formatoVenta: IFormatoVenta = Object.assign({}, this.formGroup.value);
    console.table(formatoVenta); //ver usuario por consola
    if (this.modoEdicion) {
      // edita
      formatoVenta.id = this.formatoVentaId;
      /*this.formatoVentasService.updateformatoVenta(formatoVenta)
        .subscribe(formatoVenta => this.onSaveSuccess(),
          error => this.alertService.error(error.message));*/
    } else {
      // crea
      this.formatoVentaService.createFormatoVenta(formatoVenta)
        .subscribe(formatoVenta => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/formatoVenta"]);
    this.alertService.success("Guardado Exitoso");
  }

  get nombre() {
    return this.formGroup.get('nombre');
  }
  get abreviacion() {
    return this.formGroup.get('abreviacion');
  }
  get metrica() {
    return this.formGroup.get('metrica');
  }
  get factorConversion() {
    return this.formGroup.get('factorConversion');
  }  
}

