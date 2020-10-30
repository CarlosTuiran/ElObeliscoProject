import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IEmpleado } from 'src/app/empleados/empleados.component';
import { EmpleadosService } from 'src/app/empleados/empleados.service';
import { ITercero } from 'src/app/terceros/terceros.component';
import { TercerosService } from 'src/app/terceros/terceros.service';
import { FacturasService } from '../facturas.service';
import { ITipoMovimiento} from '../tipo-movimentos/tipo-movimentos.component';
import { TipoMovimientosService } from '../tipo-movimentos/tipo-movimientos.service';
import {IProducto} from 'src/app/productos/productos.component';
import { IBodega } from 'src/app/bodegas/bodegas.component';
import { IPromocion } from 'src/app/promociones/promociones.component';
@Component({
  selector: 'app-facturas-form',
  templateUrl: './facturas-form.component.html',
  styleUrls: ['./facturas-form.component.css']
})
export class FacturasFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private facturasService: FacturasService,
     private router: Router, private activatedRoute: ActivatedRoute, 
     private tercerosService: TercerosService, private empleadosService: EmpleadosService,
     private tipoMovimientoService: TipoMovimientosService,) { }

  modoEdicion: boolean = false;
  empleados: IEmpleado[];
  terceros: ITercero[];
  tipoMovimientos: ITipoMovimiento[];
  referencias: IProducto[];
  bodegas: IBodega[];
  promociones: IPromocion[];
  usuarioId: number;

  formGroup = this.fb.group({
    
   empleadoId :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   tercerosId :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   tipoMovimientoId :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   tipoMovimiento:['', [Validators.required]],
   fechaPago:[''],
   //subTotal :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   valorDevolucion :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   descuento :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   iVA :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   abono :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   estadoFactura:['', [Validators.required]],
   dfacturas:this.fb.array([])
  });

  ngOnInit() {
    this.tercerosService.getTerceros()
      .subscribe(terceros => this.terceros = terceros,
        error => console.error(error));
    this.empleadosService.getEmpleados()
      .subscribe(empleados=> this.empleados = empleados,
        error => console.error(error));
    this.tipoMovimientoService.getTipoMovimientos()
        .subscribe(tipoMovimientos => this.tipoMovimientos = tipoMovimientos,
          error => console.error(error));
  
  }
  get empleadoId() {
    return this.formGroup.get('empleadoId');
  }
  get tercerosId() {
    return this.formGroup.get('tercerosId');
  }
  get tipoMovimientoId () {
    return this.formGroup.get('tipoMovimientoId');
  }
  get tipoMovimiento() {
    return this.formGroup.get('tipoMovimiento');
  }
  get fechaPago() {
    return this.formGroup.get('fechaPago');
  }
  
  get valorDevolucion() {
    return this.formGroup.get('valorDevolucion');
  }
  get descuento() {
    return this.formGroup.get('descuento');
  }
  get iVA() {
    return this.formGroup.get('iVA');
  }
  get abono() {
    return this.formGroup.get('abono');
  }
  get estadoFactura() {
    return this.formGroup.get('estadoFactura');
  }
  get dfacturas() {
    return this.formGroup.get('dfacturas') as FormArray;
  }
  get referencia() {
    return this.formGroup.get('referencia');
  }
  get promocionId() {
    return this.formGroup.get('promocionId');
  }
  get bodega() {
    return this.formGroup.get('bodega');
  }
  get cantidad() {
    return this.formGroup.get('cantidad');
  }
  agregarDFactura(){
    const dFacturaFormGroup=this.fb.group({
      referencia :['', [Validators.required]],
      promocionId :[''],
      bodega :['', [Validators.required]],
      cantidad:['1', [Validators.required, Validators.pattern(/^\d+$/)]]            
    });
    this.dfacturas.push(dFacturaFormGroup);
  }
  removerDFactura(indice:number){
    this.dfacturas.removeAt(indice);
  }
  refresh(){
    this.formGroup.patchValue({
      empleadoId :'',
      tercerosId :'',
      tipoMovimientoId :'',
      tipoMovimiento:'',
      fechaPago:[''],
      //subTotal :['', [Validators.required, Validators.pattern(/^\d+$/)]],
      valorDevolucion :'',
      descuento :'',
      iVA :'',
      abono :'',
      estadoFactura:''
    });
    this.dfacturas.controls.splice(0, this.dfacturas.length);
  }
} 
