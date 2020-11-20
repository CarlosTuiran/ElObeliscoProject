import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ITipoMovimiento } from '../../facturas/tipo-movimentos/tipo-movimentos.component';
import { TipoMovimientosService } from '../../facturas/tipo-movimentos/tipo-movimientos.service';

@Component({
  selector: 'app-tipo-movimiento-select',
  templateUrl: './tipo-movimiento-select.component.html',
  styleUrls: ['./tipo-movimiento-select.component.css']
})
export class TipoMovimientoSelectComponent implements OnInit {

  keyword='nombre';
  data: ITipoMovimiento[];
  item:ITipoMovimiento;
  
  @Output() messageEvent= new EventEmitter<ITipoMovimiento>();

  constructor(private service: TipoMovimientosService) { }

  ngOnInit() {
    this.service.getTipoMovimientos()      
    .subscribe(datos => this.data = datos as ITipoMovimiento[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }


}
