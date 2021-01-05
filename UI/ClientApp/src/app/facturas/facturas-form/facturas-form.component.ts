import { Component, OnInit, ViewChild, Input } from '@angular/core';
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
import { Observable, ReplaySubject, Subject, Subscription } from 'rxjs';
import { MatSelect } from '@angular/material/select';
import { debounceTime, delay, filter, map, take, takeUntil, tap, startWith } from 'rxjs/operators';
import { IMFactura } from '../facturas.component';
import { BodegasService } from 'src/app/bodegas/bodegas.service';
import { ProductosService } from '../../productos/productos.service';

@Component({
  selector: 'app-facturas-form',
  templateUrl: './facturas-form.component.html',
  styleUrls: ['./facturas-form.component.css']
})
export class FacturasFormComponent implements OnInit {
  
  constructor(private fb: FormBuilder, private facturasService: FacturasService,
    private router: Router, private activatedRoute: ActivatedRoute, 
    private tercerosService: TercerosService, private empleadosService: EmpleadosService,
    private tipoMovimientoService: TipoMovimientosService, 
    private bodegasService: BodegasService, private productosService: ProductosService) { }
    
    modoEdicion: boolean = false;
    empleados: IEmpleado[]=[];
    terceros: ITercero[];
    productos: IProducto[];
   
  //Selecciones escogidas
  currentEmpleado="";
  currentTerceros="";
  currentTipoMovimiento="";
  currentPromocion="";
  currentProductoDescripcion="";
  currentProductoReferencia="";

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
      /** indicate search operation is in progress */
   public searching = false;
  //Filtros selects empleado
  
  filteredOptions: Observable<IProducto[]>;

  //Otro Intento del select
/*@Input() set empleados(dataEmpleados:IEmpleado[]){
  this._data=dataEmpleados;
  this.filteredEmpleados.next(this.empleados.slice());
} 
get dataEmpleados:IEmpleado[]{
  return this.dataEmpleados;
}
private _data:IEmpleado[];*/
//Fin del intento

  formGroup = this.fb.group({
    
   empleadoId :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   tercerosId :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   tipoMovimientoId :['', [Validators.required, Validators.pattern(/^\d+$/)]],
   tipoMovimiento:['', [Validators.required]],
   fechaPago:[''],
   subTotal :['1', [Validators.required, Validators.pattern(/^\d+$/)]],
   valorDevolucion :['0', [Validators.pattern(/^\d+$/)]],
   descuento :['0', [Validators.pattern(/^\d+$/)]],
   iVA :['0', [ Validators.pattern(/^\d+$/)]],
   abono :['0', [ Validators.pattern(/^\d+$/)]],
   estadoFactura:['', [Validators.required]],
   dFacturas:this.fb.array([])
  });


  ngOnInit() {
    /*this.tercerosService.getTerceros()
      .subscribe(terceros => {this.terceros = terceros;
      console.log(this.terceros); console.log(terceros);},
        error => console.error(error));*/
        /*
    this.empleadosService.getEmpleados()
      .subscribe(empleados=> this.empleados = empleados,
        error => console.error(error) 
        ); 
    this.tipoMovimientoService.getTipoMovimientos()
        .subscribe(tipoMovimientos => this.tipoMovimientos = tipoMovimientos,
          error => console.error(error));*/
      
      
              
    this.filteredEstados.next(this.estados.slice());
    
    // listen for search field value changes
    this.estadoFilter.valueChanges
    .pipe(takeUntil(this._onDestroy))
    .subscribe(() => {
      this.filterEstados();
    });
    this.bodegas=this.bodegasService.getBodegas()
       
  }
  //obtiene la lista de productos de forma asincrona
  getInfo(productos:IProducto[]){
    this.productos=productos;
    console.log(this.productos);
    /*this.filteredOptions = this.referencia.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );*/
  }
  
  ngAfterViewInit() {
    this.setInitialValue();
  }
  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }
  save() {
    let mfactura: IMFactura = Object.assign({}, this.formGroup.value);
    console.table(mfactura); //ver mfactura por consola
    console.log(this.fechaPago);

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
  get dFacturas() {
    return this.formGroup.get('dFacturas') as FormArray;
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
    if(this.currentProductoReferencia==""){
      //mensaje que debe ingresar seleccionar un producto primero
    }else{
    this.dFacturaFormGroup=this.fb.group({
      referencia :[this.currentProductoReferencia, [Validators.required]],
      promocionId :['0'],
      bodega :['', [Validators.required]],
      cantidad:['1', [Validators.required, Validators.pattern(/^\d+$/)]]            
    });
    this.dFacturas.push(this.dFacturaFormGroup);
  }
      
    
  }
  removerDFactura(indice:number){
    this.dFacturas.removeAt(indice);
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
    this.dFacturas.controls.splice(0, this.dFacturas.length);
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
  //Recibe la idEmpleado desde el componente select
  receiveMessageEmpleado($event){
    this.empleadoId.setValue($event.id);
    this.currentEmpleado = $event.nombres + " - " + $event.idEmpleado;
  }
  receiveMessageTerceros($event){
    this.tercerosId.setValue($event.id);
    this.currentTerceros = $event.nombre +" - "+ $event.nit;
  }
  receiveMessageTipoMovimiento($event){
    this.tipoMovimientoId.setValue($event.idMovimiento);
    this.currentTipoMovimiento=$event.nombre;
  }
  receiveMessagePromocion($event){
    this.promocionId.setValue($event.nombre);//pos solo se usara el nombre de la promocion como ID parece
    this.currentPromocion=$event.nombre;
  }
  receiveMessageProducto($event){
    
    this.currentProductoDescripcion=$event.descripcion;
    this.currentProductoReferencia=$event.referencia;
  }
} 
export class Estado{
  nombre:string
}
