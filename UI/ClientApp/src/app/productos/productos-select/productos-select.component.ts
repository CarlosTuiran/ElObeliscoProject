import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IProducto } from '../productos.component';
import { ProductosService } from '../productos.service';

@Component({
  selector: 'app-productos-select',
  templateUrl: './productos-select.component.html',
  styleUrls: ['./productos-select.component.css']
})
export class ProductosSelectComponent implements OnInit {

  keyword='descripcion';
  data: IProducto[];
  item:IProducto;
  
  @Output() messageEvent= new EventEmitter<IProducto>();

  constructor(private service: ProductosService) { }

  ngOnInit() {
    this.service.getProductos()      
    .subscribe(datos => this.data = datos as IProducto[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }


}
