import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ITercero } from '../terceros.component';
import { TercerosService } from '../terceros.service';

@Component({
  selector: 'app-terceros-select',
  templateUrl: './terceros-select.component.html',
  styleUrls: ['./terceros-select.component.css']
})
export class TercerosSelectComponent implements OnInit {

  keyword='nombre';
  data: ITercero[];
  item:ITercero;
  @Input() TipoMov:string;
  @Output() messageEvent= new EventEmitter<ITercero>();

  constructor(private service: TercerosService) { }

  ngOnInit() {
    this.service.getTercerostipoTercero(this.TipoMov)      
    .subscribe(datos => this.data = datos as ITercero[],
      error => console.error(error));
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }


}
