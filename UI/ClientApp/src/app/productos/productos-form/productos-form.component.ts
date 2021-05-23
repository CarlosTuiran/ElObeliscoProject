import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { IProducto } from '../productos.component';
import { ProductosService } from '../productos.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IFormatoVenta } from '../../formato-venta/formato-venta.component';
import { FormatoVentaService } from '../../formato-venta/formato-venta.service';
import { IMarca } from '../../configuraciones/marca/marca.component';
import { ICategoria } from '../../configuraciones/categoria/categoria.component';
import { ITercero } from '../../terceros/terceros.component';
import { MarcaService } from '../../configuraciones/marca/marca.service';
import { CategoriaService } from '../../configuraciones/categoria/categoria.service';
import { TercerosService } from '../../terceros/terceros.service';
import { error } from 'jquery';
import { ReplaySubject } from 'rxjs';
import { ICuenta } from '../../contabilidad/cuenta/cuenta.component';

@Component({
  selector: 'app-productos-form',
  templateUrl: './productos-form.component.html',
  styleUrls: ['./productos-form.component.css']
})
export class ProductosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private productosService: ProductosService,
    private router: Router, private formatoVentaService: FormatoVentaService,
    private activatedRoute: ActivatedRoute, private marcaService: MarcaService,
    private categoriaService: CategoriaService, private terceroService: TercerosService,
    private alertService: AlertService) { }

  modoEdicion: boolean = false;
  productoId: string;
  formatosVenta: IFormatoVenta[];
  marcas: IMarca[];
  categorias: ICategoria[];
  proveedores: ITercero[];
 


//Filtros de select cuenta
public cuentaFilter:FormControl= new FormControl();
public filteredcuentas: ReplaySubject<ICuenta[]> = new ReplaySubject<ICuenta[]>(1);
//@ViewChild('cuentaSelect', { static: true }) singleCuentaSelect: MatSelect;

  formGroup = this.fb.group({
    referencia: ['', [Validators.required]],
    descripcion: ['', [Validators.required]],
    formatoVenta: ['', [Validators.required]],
    idMarca: ['', [Validators.required]],
    idCategoria: ['', [Validators.required]],
    idProveedor: ['', [Validators.required]],
    fabrica: ['', [Validators.required]],
    costo: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
    precioVenta: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
    iVA: ['0', [Validators.required]],
    cantidadMinima:['', [Validators.required, Validators.pattern(/^\d+$/)]],
    cuentaIngreso:['',[Validators.required]]
  });
 
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.productoId = params["id"];
      this.productosService.getProducto(this.productoId).subscribe(producto => this.cargarFormulario(producto),
        error => this.alertService.error(error.error));
    });
    this.formatoVentaService.getFormatosVenta().subscribe(
      formatos => this.formatosVenta=formatos,
        error => this.alertService.error(error.message)
    );

    this.marcaService.getMarcas().subscribe(marcas => this.marcas = marcas,
      error => this.alertService.error(error.message));
    this.categoriaService.getCategorias().subscribe(categorias => this.categorias = categorias,
      error => this.alertService.error(error.message));
    this.terceroService.getTercerostipoTercero("Compra").subscribe(terceros => this.proveedores = terceros,
      error => this.alertService.error(error.message));

  }
  cargarFormulario(producto: IProducto) {
    console.log(producto);
    this.formGroup.patchValue({
      referencia: producto.referencia,
      descripcion: producto.descripcion,
      formatoVenta: producto.formatoVenta,
      fabrica: producto.fabrica,
      idMarca: producto.idMarca,
      idCategoria: producto.idCategoria,
      idProveedor: producto.idProveedor,
      costo: producto.costo,
      precioVenta: producto.precioVenta,
      iVA: producto.iva,
      cantidadMinima:producto.cantidadMinima
    });
  }

  save() {
    let producto: IProducto = Object.assign({}, this.formGroup.value);
    console.table(producto); //ver usuario por consola
    if (this.modoEdicion) {
      // edita
      producto.referencia = this.productoId;
      this.productosService.updateProducto(producto)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea
      this.productosService.createProductos(producto)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/productos"]);
    this.alertService.success("Guardado Exitoso");
  }

  get referencia() {
    return this.formGroup.get('referencia');
  }
  get descripcion() {
    return this.formGroup.get('descripcion');
  }
  get formatoVenta() {
    return this.formGroup.get('formatoVenta');
  }
  get idMarca() {
    return this.formGroup.get('idMarca');
  }
  get idCategoria() {
    return this.formGroup.get('idCategoria');
  }
  get idProveedor() {
    return this.formGroup.get('idProveedor');
  }
  get fabrica() {
    return this.formGroup.get('fabrica');
  }
  get costo() {
    return this.formGroup.get('costo');
  }
  get precioVenta() {
    return this.formGroup.get('precioVenta');
  }
  get iVA() {
    return this.formGroup.get('iVA');
  }
  get cantidadMinima() {
    return this.formGroup.get('cantidadMinima');
  }
  get cuentaIngreso(){
    return this.formGroup.get('cuentaIngreso');
  }
  //Recibe la idCuenta desde el componente select
  receiveMessageCuentaIngreso($event){
    this.cuentaIngreso.setValue($event.id);   
  }
}
