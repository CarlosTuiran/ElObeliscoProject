import { Component, OnInit, ViewChild } from '@angular/core';
import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';
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
import { ReplaySubject, Subject, Subscription } from 'rxjs';
import { MatSelect } from '@angular/material/select';
import { take, takeUntil } from 'rxjs/operators';
import { IMFactura } from '../facturas.component';

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
  public tercerosX: ITercero[];
  //tercerosX: Subscription=null;
  tipoMovimientos: ITipoMovimiento[];
  referencias: IProducto[];
  bodegas: IBodega[];
  promociones: IPromocion[];
  estados:Estado[]= [{'nombre':'Pagada'}, {'nombre':'Pendiente'}];
  usuarioId: number;
  dFacturaFormGroup;
  protected _onDestroy = new Subject<void>();
  //Filtros de select estado
  public estadoFilter:FormControl= new FormControl();
  public filteredEstados: ReplaySubject<Estado[]> = new ReplaySubject<Estado[]>(1);
  @ViewChild('estadoSelect', { static: true }) singleEstadoSelect: MatSelect;
  //Filtros de select empleado
  public empleadoFilter:FormControl= new FormControl();
  public filteredEmpleados: ReplaySubject<IEmpleado[]> = new ReplaySubject<IEmpleado[]>(1);
  @ViewChild('empleadoSelect', { static: true }) singleEmpleadoSelect: MatSelect;
  
  
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
        error => console.error(error) 
        ); 
    /*this.tipoMovimientoService.getTipoMovimientos()
        .subscribe(tipoMovimientos => this.tipoMovimientos = tipoMovimientos,
          error => console.error(error));*/
    // load the initial  list
    //this.tercerosX=this.tercerosService.getTerceros().subscribe();
    //console.log(this.tercerosX[0]);

    this.filteredEstados.next(this.estados.slice());
    this.filteredEmpleados.next(this.empleados.slice());    
    // listen for search field value changes
    this.estadoFilter.valueChanges
    .pipe(takeUntil(this._onDestroy))
    .subscribe(() => {
      this.filterEstados();
    });
    this.empleadoFilter.valueChanges
    .pipe(takeUntil(this._onDestroy))
    .subscribe(() => {
      this.filterEmpleados();
    });
  }
  consulta(tercerosX:ITercero[]){
    //console.log(tercerosX[0]);
  }
  ngAfterViewInit() {
    this.setInitialValue();
  }
  /*ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }*/
  save() {
    let mfactura: IMFactura = Object.assign({}, this.formGroup.value);
    console.table(mfactura); //ver mfactura por consola
    

    if (this.modoEdicion) {
      /* edita un mfactura
      mfactura.empleadoId = this.mfacturaId;
      this.mfacturasService.updatemfactura(mfactura)
        .subscribe(mfactura => this.onSaveSuccess(),
          error => console.error(error));*/
    } else {
      // crea un mfactura
      this.facturasService.createFacturas(mfactura)
        .subscribe(mfactura => this.onSaveSuccess(),
          error => console.error(error));
    }
  }
  onSaveSuccess(){
    this.router.navigate(["/facturas"]);
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
    return this.dFacturaFormGroup.get('referencia');
  }
  get promocionId() {
    return this.dFacturaFormGroup.get('promocionId');
  }
  get bodega() {
    return this.dFacturaFormGroup.get('bodega');
  }
  get cantidad() {
    return this.dFacturaFormGroup.get('cantidad');
  }
  agregarDFactura(){
    this.dFacturaFormGroup=this.fb.group({
      referencia :['', [Validators.required]],
      promocionId :[''],
      bodega :['', [Validators.required]],
      cantidad:['1', [Validators.required, Validators.pattern(/^\d+$/)]]            
    });
    this.dfacturas.push(this.dFacturaFormGroup);
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
    /**
   * Sets the initial value after the filteredBanks are loaded initially
   */
  protected setInitialValue() {
    this.filteredEstados
      .pipe(take(1), takeUntil(this._onDestroy))
      .subscribe(() => {
        // setting the compareWith property to a comparison function
        // triggers initializing the selection according to the initial value of
        // the form control (i.e. _initializeSelection())
        // this needs to be done after the filteredBanks are loaded initially
        // and after the mat-option elements are available
        this.singleEstadoSelect.compareWith = (a: Estado, b: Estado) => a && b && a.nombre === b.nombre;
      });
      this.filteredEmpleados
      .pipe(take(1), takeUntil(this._onDestroy))
      .subscribe(() => {
        this.singleEmpleadoSelect.compareWith = (a: IEmpleado, b: IEmpleado) => a && b && a.idEmpleado === b.idEmpleado;
      });
  }
  
  protected filterEstados() {
    if (!this.estados) {
      return;
    }
    // get the search keyword
    let search = this.estadoFilter.value;
    if (!search) {
      this.filteredEstados.next(this.estados.slice());
      return;
    } else {
      search = search.toLowerCase();
    }
    // filter the estados
    this.filteredEstados.next(
      this.estados.filter(estado => estado.nombre.toLowerCase().indexOf(search) > -1)
    );
  }
  protected filterEmpleados() {
    if (!this.empleados) {
      return;
    }
    // get the search keyword
    let search = this.empleadoFilter.value;
    if (!search) {
      this.filteredEmpleados.next(this.empleados.slice());
      return;
    } else {
      search = search.toLowerCase();
    }
    // filter the empleados
    this.filteredEmpleados.next(
      this.empleados.filter(empleado => empleado.nombres.toLowerCase().indexOf(search) > -1)
    );
  }
} 
export class Estado{
  nombre:string
}
