import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router, UrlSegment } from '@angular/router';
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
import { AlertService } from '../../notifications/_services';
import { DialogoCrearFacturaComponent } from './dialogo-crear-factura/dialogo-crear-factura.component';


//import { MatDialog } from '@angular/material/typings';
import { MatDialog } from '@angular/material/dialog';
import { IFormatoVenta } from '../../formato-venta/formato-venta.component';
import { FormatoVentaService } from '../../formato-venta/formato-venta.service';
//import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-facturas-form',
  templateUrl: './facturas-form.component.html',
  styleUrls: ['./facturas-form.component.css']
})
export class FacturasFormComponent implements OnInit {
  isAdmin = false;
  constructor(private fb: FormBuilder, private facturasService: FacturasService,
    private router: Router, private activatedRoute: ActivatedRoute, 
    private tercerosService: TercerosService, private empleadosService: EmpleadosService,
    private tipoMovimientoService: TipoMovimientosService, 
    private bodegasService: BodegasService, private productosService: ProductosService, 
    private alertService: AlertService, public dialog: MatDialog,
    private formatoVentaService: FormatoVentaService) { }


  modoEdicion: boolean = false;
  empleados: IEmpleado[] = [];
  terceros: ITercero[];
  productos: IProducto[];
  formatosVenta: IFormatoVenta[];

  //Selecciones escogidas
  currentEmpleado="";
  currentTerceros="";
  currentTipoMovimiento="";
  currentPromocion="";
  currentProductoDescripcion="";
  currentProductoReferencia = "";
  currentProductoPrecio = 0;
  currentProductoIva = 0;
  currentProductoFormato = "";
  //Lista de Productos escogidos
  referenciasEscogidas: string[] = [];

  //Variable de Subtotal
  SubTotal = 0;
  Calculoiva = 0;

  //dialogRta respuesta a la ventana de dialogo
  dialogRta = "";
  //* Tipo Movimiento Compra/Venta 
  TipoMov :string;

  tipoMovimientos: ITipoMovimiento[];
  referencias: IProducto[];
  bodegas: IBodega[];
  promociones: IPromocion[];
  estados:Estado[]= [{'nombre':'Pagada'}, {'nombre':'Pendiente'}];
  usuarioId: number;
  Formatos:IFormatoVenta[];
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
   tipoMovimientoId: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
   //tipoMovimiento:[''],
   fechaPago:[''],
   subTotal :['1', [Validators.required, Validators.pattern(/^\d+$/)]],
   valorDevolucion :['0', [Validators.pattern(/^\d+$/)]],
   descuento :['0', [Validators.pattern(/^\d+$/)]],
    abono: ['0', [Validators.pattern(/^\d+$/)]],
    ivaTotal: ['0', [Validators.pattern(/^\d+$/)]],
   //estadoFactura:['', [Validators.required]],
   dFacturas:this.fb.array([])
  });


  ngOnInit() {
    const segments: UrlSegment[] = this.activatedRoute.snapshot.url;
    if (segments[0].toString() == 'facturas-crearVenta') {
      this.TipoMov = "Venta";
    } else {
      this.TipoMov = "Compra";
    }

    this.formatoVentaService.getFormatosVenta().subscribe(
      formatos => this.Formatos = formatos,
      error => this.alertService.error(error));

    this.tipoMovimientoService.getTipoMovimientos()      
    .subscribe(datos =>{ this.tipoMovimientos = datos as ITipoMovimiento[]},
      error => console.error(error));
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
    this.calcSubTotal(mfactura);
    console.table(mfactura); //ver mfactura por consola
  }
  //* funcion evento para calcular Subtotal
  calcSubTotal(mfactura:IMFactura){
    //llamar a la funcion de prefacturacion
    this.facturasService.precreateFacturas(mfactura)
      .subscribe(mfactura => {
        this.SubTotal = mfactura.subTotal; 
          console.log(mfactura);
          this.openDialog();
        },
          error => {this.alertService.error(error.message); console.log(error)}
        );    
    }
    //Abrir ventana de dialogo para guardar factura
    openDialog() {
        const dialogRef = this.dialog.open(DialogoCrearFacturaComponent, {
            width: '250px',
            data: { subTotal: this.SubTotal }
        });

        dialogRef.afterClosed().subscribe(result => {
            this.dialogRta = result;
            let mfactura: IMFactura = Object.assign({}, this.formGroup.value);
            mfactura.tipoMovimiento=this.TipoMov;
            if (this.dialogRta) {
              mfactura.subTotal = this.SubTotal;
              // crea un mfactura
              this.facturasService.createFacturas(mfactura)
                .subscribe(mfactura => this.onSaveSuccess(),
                  error => {this.alertService.error(error.error);}
                );
         }
        });
    }
  onSaveSuccess(){
    this.router.navigate(["/facturas"]);
    this.alertService.success("Guardado Exitoso");
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
 /* get tipoMovimiento() {
    return this.formGroup.get('tipoMovimiento');
  }*/
  get fechaPago() {
    return this.formGroup.get('fechaPago');
  }
  
  get valorDevolucion() {
    return this.formGroup.get('valorDevolucion');
  }
  get descuento() {
    return this.formGroup.get('descuento');
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
  get iva() {
    return this.dFacturaFormGroup.get('iva');
  }
  get formatoVenta(){
    return this.dFacturaFormGroup.get('formatoVenta');
  }
  get cantidad() {
    return this.dFacturaFormGroup.get('cantidad');
  }
  get precioUnitario() {
    return this.dFacturaFormGroup.get('precioUnitario');
  }
  get descripcion() {
    return this.dFacturaFormGroup.get('descripcion');
  }
  agregarDFactura() {
    if (this.currentProductoReferencia == "") {
      //mensaje que debe ingresar seleccionar un producto primero
    } else {
      let referenciaFinder = this.referenciasEscogidas.find(t => t == this.currentProductoReferencia);//busca si existe tal referencia en la lista dfacturas
      if (referenciaFinder) {
        this.alertService.error("Producto ya Seleccionado")
      } else {
          this.dFacturaFormGroup = this.fb.group({
              referencia: [this.currentProductoReferencia, [Validators.required]],
              descripcion:[this.currentProductoDescripcion],
              promocionId: ['0'],
              bodega: ['', [Validators.required]],
              formatoVenta:['',[Validators.required] ],
              precioUnitario: [this.currentProductoPrecio],
              iva: [this.currentProductoIva, [Validators.required]],
              cantidad: ['1', [Validators.required, Validators.pattern(/^\d+$/)]]
        });
        this.referenciasEscogidas.push(this.currentProductoReferencia);
        this.dFacturas.push(this.dFacturaFormGroup);
        this.cantidadCapture();
      }
    }
  }
  //calculo del subtotal dinamico
  cantidadCapture(){
    this.SubTotal = 0;
    this.Calculoiva =0;
    for (let index = 0; index < this.referenciasEscogidas.length; index++) {
      var cantidad = this.dFacturas.controls[index].value.cantidad;
      var iva = this.dFacturas.controls[index].value.iva;
      var formatoProducto=this.dFacturas.controls[index].value.formatoVenta; console.log("R1:"+formatoProducto);
      var precio=this.dFacturas.controls[index].value.precioUnitario;
      var formatoConvert=this.Formatos.filter(x=>x.nombre==formatoProducto); console.log("R2:"+formatoConvert[0].factorConversion);
      this.SubTotal = this.SubTotal + (cantidad * (precio/formatoConvert[0].factorConversion));
      this.Calculoiva = this.Calculoiva + ((cantidad * precio) * (iva / 100));
    }
    
  }
  removerDFactura(indice:number){
    let referenciaaEliminar=this.dFacturas.controls[indice].value.referencia;
    this.referenciasEscogidas.splice(referenciaaEliminar);
    this.dFacturas.removeAt(indice);
  }
  refresh(){
    this.formGroup.patchValue({
      empleadoId :'',
      tercerosId :'',
      tipoMovimientoId :'',
      //tipoMovimiento:'',
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
    this.currentProductoReferencia = $event.referencia;
    this.formatoVentaService.getFormatos($event.referencia).subscribe(
      formatos => this.formatosVenta = formatos,
      error =>  this.alertService.error(error.error.message));
    this.currentProductoFormato=$event.formatoVenta;
    this.currentProductoIva = $event.iva;
    if(this.TipoMov == 'Compra'){
      this.currentProductoPrecio=$event.costo;
    }else{
      this.currentProductoPrecio=$event.precioVenta;
    }
 
  }
} 
export class Estado{
  nombre:string
}
