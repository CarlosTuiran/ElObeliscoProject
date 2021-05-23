import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { IProducto, IProducto2 } from '../productos.component';
import { ProductosService } from '../productos.service';

@Component({
  selector: 'app-productos-select',
  templateUrl: './productos-select.component.html',
  styleUrls: ['./productos-select.component.css']
})
export class ProductosSelectComponent implements OnInit {

  keyword='descripcion';
  data: IProducto2[];
  item:IProducto2;
  
  @Output() messageEvent= new EventEmitter<IProducto2>();

  constructor(private service: ProductosService) { }

  ngOnInit() {
    this.service.getProductos()      
    .subscribe(datos => this.data = datos as IProducto2[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }
 

}
