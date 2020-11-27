import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { INomina } from '../nomina.component';
import { NominaService } from '../nomina.service';

@Component({
  selector: 'app-table-nomina',
  templateUrl: './table-nomina.component.html',
  styleUrls: ['./table-nomina.component.css']
})
export class TableNominaComponent implements OnInit {

  nominas!:INomina[];  
  displayedColumns: string[] = [
    'idEmpleado',
    'diasTrabajados',
    'horasExtras',
    'salarioBase',
    'subTransporte'];
    
    dataSource =new MatTableDataSource<INomina>(this.nominas);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private nominaService: NominaService){}
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.nominaService.getNominas()
    .subscribe(nominas => this.dataSource.data = nominas,
      error => console.error(error));

  }

}
