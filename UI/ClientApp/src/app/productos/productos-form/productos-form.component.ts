import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { IProducto } from '../productos.component';
import { ProductosService } from '../productos.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-productos-form',
  templateUrl: './productos-form.component.html',
  styleUrls: ['./productos-form.component.css']
})
export class ProductosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private productosService: ProductosService,
    private router: Router, private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  productoId: string;

  formGroup = this.fb.group({
    referencia: ['', [Validators.required]],
    descripcion: ['', [Validators.required]],
    formatoVenta: ['', [Validators.required]],
    marca: ['', [Validators.required]],
    fabrica: ['', [Validators.required]],
    costo: ['', [Validators.required, Validators.pattern(/^\d+$/)]],
    precioVenta: ['', [Validators.required, Validators.pattern(/^\d+$/)]]
  });
 
  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.productoId = params["id"];
      this.productosService.getProducto(this.productoId).subscribe(producto => this.cargarFormulario(producto),
        error => console.error(error));
    });
  }
  cargarFormulario(producto: IProducto) {
    this.formGroup.patchValue({
      referencia: producto.referencia,
      descripcion: producto.descripcion,
      formatoVenta: producto.formatoVenta,
      fabrica: producto.fabrica,
      marca: producto.marca,
      costo: producto.costo,
      precioVenta: producto.precioVenta
    });
  }

  save() {
    let producto: IProducto = Object.assign({}, this.formGroup.value);
    console.table(producto); //ver usuario por consola
    if (this.modoEdicion) {
      // edita un usuario
      producto.referencia = this.productoId;
      this.productosService.updateProducto(producto)
        .subscribe(usuario => this.onSaveSuccess(),
          error => console.error(error));
    } else {
      // crea un usuario
      this.productosService.createProductos(producto)
        .subscribe(usuario => this.onSaveSuccess(),
          error => console.error(error));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/productos"]);
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
  get marca() {
    return this.formGroup.get('marca');
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
}
