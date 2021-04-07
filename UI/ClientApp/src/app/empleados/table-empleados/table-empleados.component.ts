import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { IEmpleado } from '../empleados.component';
import { EmpleadosService } from '../empleados.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { error } from '@angular/compiler/src/util';

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
    'fechaIngreso',
    'options'];
  dataSource =new MatTableDataSource<IEmpleado>(this.empleados);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private empleadosService: EmpleadosService, private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService){}
  
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

  Eliminar(empleadoId: number) {
    this.empleadosService.deleteEmpleado(empleadoId).
      subscribe(empleadoId => this.onDeleteSuccess(),
        error => console.error(error))
  }

  onDeleteSuccess() {
    this.router.navigate(["/empleados"]);
    this.alertService.success("Eliminado exitoso");
  }

}
