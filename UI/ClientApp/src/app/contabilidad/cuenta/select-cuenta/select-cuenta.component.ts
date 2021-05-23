import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { ICuenta } from '../cuenta.component';
import { CuentaService } from '../cuenta.service';

@Component({
  selector: 'app-select-cuenta',
  templateUrl: './select-cuenta.component.html',
  styleUrls: ['./select-cuenta.component.css']
})
export class SelectCuentaComponent implements OnInit {

  keyword='nombre';
  data: ICuenta[];
  item:ICuenta;
  
  @Output() messageEvent= new EventEmitter<ICuenta>();

  constructor(private service: CuentaService) { }

  ngOnInit() {
    this.service.getCuentas()      
    .subscribe(datos => this.data = datos as ICuenta[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }

}
