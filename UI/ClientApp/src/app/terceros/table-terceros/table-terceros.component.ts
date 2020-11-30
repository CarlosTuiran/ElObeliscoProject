import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ITercero } from '../terceros.component';
import { TercerosService } from '../terceros.service';

@Component({
  selector: 'app-table-terceros',
  templateUrl: './table-terceros.component.html',
  styleUrls: ['./table-terceros.component.css']
})
export class TableTercerosComponent implements OnInit {

  
  terceros!:ITercero[];  
  displayedColumns: string[] = [
    'nit',
    'nombre',
    'apellido',
    'tipoTercero',
    'celular',
    'correo',
    'direccion',
    'descripcion',
    'options'];
  dataSource =new MatTableDataSource<ITercero>(this.terceros);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private tercerosService: TercerosService){}
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.tercerosService.getTerceros()
    .subscribe(terceros => this.dataSource.data = terceros,
      error => console.error(error));

  }

}
