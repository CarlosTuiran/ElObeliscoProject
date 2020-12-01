import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { IEmpleado } from '../empleados.component';
import { EmpleadosService } from '../empleados.service';

@Component({
  selector: 'app-table-empleados',
  templateUrl: './table-empleados.component.html',
  styleUrls: ['./table-empleados.component.css']
})
export class TableEmpleadosComponent implements OnInit {

  empleados!:IEmpleado[];  
  displayedColumns: string[] = [
    'idEmpleado',
    'nombres',
    'apellidos',
    'cargo',
    'celular',
    'correo',
    'direccion',
    'options'];
  dataSource =new MatTableDataSource<IEmpleado>(this.empleados);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private empleadosService: EmpleadosService){}
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.empleadosService.getEmpleados()
    .subscribe(empleados => this.dataSource.data = empleados,
      error => console.error(error));

  }


}
