import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { IPromocion } from '../promociones.component';
import { PromocionesService } from '../promociones.service';

@Component({
  selector: 'app-promociones-select',
  templateUrl: './promociones-select.component.html',
  styleUrls: ['./promociones-select.component.css']
})
export class PromocionesSelectComponent implements OnInit {

  keyword='nombre';
  data: IPromocion[];
  country:IPromocion;
  
  @Output() messageEvent= new EventEmitter<IPromocion>();

  constructor(private service: PromocionesService) { }

  ngOnInit() {
    this.service.getPromociones()      
    .subscribe(datos => this.data = datos as IPromocion[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }


}
