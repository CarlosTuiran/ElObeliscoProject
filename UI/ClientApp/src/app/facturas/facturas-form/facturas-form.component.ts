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
  Total = 0;

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
  
  //Los put@s select
  metricaPeso:string[]= [];
  metricaVolumen:string[]=[];  
  metricaUnidad:string[]=[];
  FormatosbyProductos:string[]=[];  

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
    fechaPago:[''],
    subTotal :[],
    valorDevolucion :['0', [Validators.pattern(/^\d+$/)]],
    descuento :['0', [Validators.pattern(/^\d+$/)]],
    abono: ['0', [Validators.pattern(/^\d+$/)]],
    iVA: [],
    total:[],
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
      formatos => {
        this.Formatos = formatos;
        this.metricaPeso = formatos.filter(x => x.metrica == "Peso").map(z => z.nombre);
        this.metricaVolumen = formatos.filter(x => x.metrica == "Volumen").map(z => z.nombre);  
        this.metricaUnidad = formatos.filter(x => x.metrica == "Unidad").map(z => z.nombre);
      },
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
    this.cantidadCapture();
    let mfactura: IMFactura = Object.assign({}, this.formGroup.value);
    mfactura.subTotal = this.SubTotal;
    mfactura.iVA = this.Calculoiva;
    mfactura.tipoMovimiento = this.TipoMov;
    mfactura.total = this.Total;
    this.facturasService.createFacturas(mfactura)
      .subscribe(mfactura => this.onSaveSuccess(),
        error => this.alertService.error(error.error)
    );
  }
  onSaveSuccess(){
    if (this.TipoMov=="Compra"){
      this.router.navigate(["/facturasCompra"]);
    }else{
      this.router.navigate(["/facturasVenta"]);
    }
    this.alertService.success("Guardado Exitoso");
  }

  cancelar() {
    if (this.TipoMov == "Compra") {
      this.router.navigate(["/facturasCompra"]);
    } else {
      this.router.navigate(["/facturasVenta"]);
    }
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
  get total() {
    return this.formGroup.get('total');
  }
  get valorDevolucion() {
    return this.formGroup.get('valorDevolucion');
  }
  get descuento() {
    return this.formGroup.get('descuento');
  }
  get iVAM() {
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
  get iva() {
    return this.dFacturaFormGroup.get('iva');
  }
  get iVA() {
    return this.dFacturaFormGroup.get('iVA');
  }
  get formatoProducto(){
    return this.dFacturaFormGroup.get('formatoProducto');
  }
  get cantidadDigitada() {
    return this.dFacturaFormGroup.get('cantidadDigitada');
  }
  get precioUnitario() {
    return this.dFacturaFormGroup.get('precioUnitario');
  }
  get descripcion() {
    return this.dFacturaFormGroup.get('descripcion');
  }
  get cantidad() {
    return this.dFacturaFormGroup.get('cantidad');
  }
  agregarDFactura() {
    if (this.currentProductoReferencia == "") {
      this.alertService.error("Seleccione un producto primero");
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
          formatoProducto:[this.currentProductoFormato,[Validators.required] ],
          formatoVentaOriginal:[this.currentProductoFormato],
          precioUnitario: [this.currentProductoPrecio],
          precioTotal:[],
          ivaProducto: [this.currentProductoIva],
          iVA: [],
          cantidad:[],
          cantidadDigitada: ['1', [Validators.required, Validators.pattern(/^\d+$/)]]
        });
        this.referenciasEscogidas.push(this.currentProductoReferencia);
        this.formatoVentaService.getFormatos(this.currentProductoReferencia).subscribe(
          formatos => {
            this.FormatosbyProductos.push(formatos[0].metrica);
            this.dFacturas.push(this.dFacturaFormGroup);
            this.cantidadCapture();
          },
          error => this.alertService.error(error.error.message));
        
      }
    }
  }
  //calculo del subtotal dinamico
  cantidadCapture(){
    this.SubTotal = 0;
    this.Calculoiva =0;
    this.Total=0;
    for (let index = 0; index < this.referenciasEscogidas.length; index++) {
      var cantidad = this.dFacturas.controls[index].value.cantidadDigitada;
      var iva = this.dFacturas.controls[index].value.ivaProducto;
      var formatoProducto=this.dFacturas.controls[index].value.formatoProducto; 
      var formatoVentaOriginal=this.dFacturas.controls[index].value.formatoVentaOriginal;
      var precio=this.dFacturas.controls[index].value.precioUnitario; console.log(formatoProducto);
      var formatoConvert=this.Formatos.filter(x=>x.nombre==formatoProducto);
      var formatoConvertOriginal=this.Formatos.filter(x=>x.nombre==formatoVentaOriginal);
      var totalProducto = ((cantidad * formatoConvert[0].factorConversion) * (precio / formatoConvertOriginal[0].factorConversion));
      var ivaProducto = totalProducto * (iva / 100);
      this.SubTotal = this.SubTotal + totalProducto;
      var calculoCantidad = totalProducto / precio;
      this.dFacturas.controls[index].value.cantidad=calculoCantidad;
      this.Calculoiva = this.Calculoiva + ivaProducto;     
      this.dFacturas.controls[index].value.precioTotal = totalProducto + ivaProducto;
      this.dFacturas.controls[index].value.iVA = ivaProducto;
    }
    console.log(this.referenciasEscogidas);
    this.Total = this.SubTotal + this.Calculoiva;
  }
  removerDFactura(indice:number){
    let referenciaaEliminar=this.dFacturas.controls[indice].value.referencia;
    this.SubTotal=this.SubTotal- (this.dFacturas.controls[indice].value.precioTotal - this.dFacturas.controls[indice].value.iVA); 
    this.Calculoiva =this.Calculoiva-this.dFacturas.controls[indice].value.iVA;
    this.Total=this.SubTotal+this.Calculoiva;
    this.FormatosbyProductos.splice(this.referenciasEscogidas.indexOf(referenciaaEliminar), 1);
    this.referenciasEscogidas.splice(this.referenciasEscogidas.indexOf(referenciaaEliminar), 1);

    this.dFacturas.removeAt(indice);
    this.cantidadCapture();
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
export interface ISuperFormato{
  formatosVenta: IFormatoVenta[];
}
