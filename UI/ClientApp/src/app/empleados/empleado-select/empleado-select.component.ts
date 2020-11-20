import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IEmpleado } from '../empleados.component';
import { EmpleadosService } from '../empleados.service';

@Component({
  selector: 'app-empleado-select',
  templateUrl: './empleado-select.component.html',
  styleUrls: ['./empleado-select.component.css']
})
export class EmpleadoSelectComponent implements OnInit {

  keyword='nombres';
  data: IEmpleado[];
  country:IEmpleado;
  
  @Output() messageEvent= new EventEmitter<IEmpleado>();

  constructor(private service: EmpleadosService) { }

  ngOnInit() {
    this.service.getEmpleados()      
    .subscribe(datos => this.data = datos as IEmpleado[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item);    
  }

}
