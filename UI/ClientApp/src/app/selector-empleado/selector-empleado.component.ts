import { Component, OnInit, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { EmpleadosService } from '../empleados/empleados.service';
import { ReplaySubject, Subject } from 'rxjs';
import { FormControl } from '@angular/forms';
import { IEmpleado } from '../empleados/empleados.component';
import { MatSelect } from '@angular/material/select';
import { takeUntil, take } from 'rxjs/operators';

@Component({
  selector: 'app-selector-empleado',
  templateUrl: './selector-empleado.component.html',
  styleUrls: ['./selector-empleado.component.css']
})
export class SelectorEmpleadoComponent implements OnInit {

  constructor(private empleadosService: EmpleadosService) { }
    //Otro Intento del select
@Input() set empleados(dataEmpleados:IEmpleado[]){
  this._data=dataEmpleados;
  this.filteredEmpleados.next(this.dataEmpleados.slice());
}
@Output() onSelectionChange: EventEmitter<IEmpleado[]>=new EventEmitter<IEmpleado[]>(); 
get dataEmpleados():IEmpleado[]{
  return this._data;
}
private _data:IEmpleado[]=[];
//Fin del intento
//Filtros de select empleado
public empleadoCtrl:FormControl=new FormControl();
public empleadoFilter:FormControl= new FormControl();
public filteredEmpleados: ReplaySubject<IEmpleado[]> = new ReplaySubject<IEmpleado[]>(1);
@ViewChild('empleadoSelect', { static: true }) singleEmpleadoSelect: MatSelect;
private _onDestroy = new Subject<void>();

  ngOnInit(): void {
    this.empleadoCtrl.setValue(this.empleados);
    this.filteredEmpleados.next(this.empleados.slice());    
    this.empleadoFilter.valueChanges
    .pipe(takeUntil(this._onDestroy))
    .subscribe(() => {
      this.filterEmpleados();
    });
  }
  ngAfterViewInit(): void{
    this.setInitialValue();
  }
  ngOnDestroy(): void{
    this._onDestroy.next();
    this._onDestroy.complete();
  }
  onChange($event){
    this.onSelectionChange.emit($event);
  }
  protected setInitialValue() {
     this.filteredEmpleados
      .pipe(take(1), takeUntil(this._onDestroy))
      .subscribe(() => {
        this.singleEmpleadoSelect.compareWith = (a: IEmpleado, b: IEmpleado) => a && b && a.idEmpleado === b.idEmpleado;
      });
  }
  protected filterEmpleados() {
    if (!this.empleados) {
      return;
    }
    // get the search keyword
    let search = this.empleadoFilter.value;
    if (!search) {
      this.filteredEmpleados.next(this.empleados.slice());
      return;
    } else {
      search = search.toLowerCase();
    }
    // filter the empleados
    this.filteredEmpleados.next(
      this.empleados.filter(empleado => empleado.nombres.toLowerCase().indexOf(search) > -1)
    );
  }
}
