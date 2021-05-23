import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { CuentaService } from '../cuenta.service';
import { FormatoVentaService } from '../../../formato-venta/formato-venta.service';
import { ICuenta } from '../cuenta.component';
import { AlertService } from '../../../notifications/_services';
@Component({
  selector: 'app-form-cuenta',
  templateUrl: './form-cuenta.component.html',
  styleUrls: ['./form-cuenta.component.css']
})
export class FormCuentaComponent implements OnInit {

  constructor(private fb: FormBuilder, private cuentasService: CuentaService,
    private router: Router,private activatedRoute: ActivatedRoute, 
    private alertService: AlertService) { }

  modoEdicion: boolean = false;
  cuentaId:number;
  clases:string[]=['Clase', 'Grupo', 'Cuenta', 'Subcuenta'];
  naturalezas:string[]=['Debe', 'Haber'];  
  formGroup = this.fb.group({  
  nombre:['', [Validators.required]],
  clase:['', [Validators.required]],
  codigo:['', [Validators.required, Validators.pattern(/^\d+$/)]],
  naturaleza:['', [Validators.required]]    
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.cuentaId = params["id"];
      this.cuentasService.getCuenta(this.cuentaId).subscribe(cuenta => this.cargarFormulario(cuenta),
        error => this.alertService.error(error.message));
    });
  }
  cargarFormulario(cuenta: ICuenta) {
    
    this.formGroup.patchValue({
      nombre:cuenta.nombre,
      tipo: cuenta.clase,
      codigo:cuenta.codigo,
      naturaleza:cuenta.naturaleza   
    });
  }

  save() {
    let cuenta: ICuenta = Object.assign({}, this.formGroup.value);
    console.table(cuenta); 
    if (this.modoEdicion) {
      // edita
      cuenta.id = this.cuentaId;
      this.cuentasService.updateCuenta(cuenta)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea
      this.cuentasService.createCuentas(cuenta)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/cuentas"]);
    this.alertService.success("Guardado Exitoso");
  }

  get nombre() {
    return this.formGroup.get('nombre');
  }
  get codigo() {
    return this.formGroup.get('codigo');
  }get naturaleza() {
    return this.formGroup.get('naturaleza');
  }get clase() {
    return this.formGroup.get('clase');
  }
}
