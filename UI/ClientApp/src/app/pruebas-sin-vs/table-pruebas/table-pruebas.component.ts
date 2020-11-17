import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IPruebaCovidReport } from '../pruebas-sin-vs.component';
import { PruebasSinVSService } from '../pruebas-sin-vs.service';

@Component({
  selector: 'app-table-pruebas',
  templateUrl: './table-pruebas.component.html',
  styleUrls: ['./table-pruebas.component.css']
})
export class TablePruebasComponent implements OnInit, AfterViewInit {

  
  pruebaDataLocal!:IPruebaCovidReport[];
  displayedColumns: string[] = ['country'];
  dataSource=new MatTableDataSource<IPruebaCovidReport>(this.pruebaDataLocal);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private service: PruebasSinVSService) { }
  
  ngOnInit() {
    this.service.pruebaCovidReports()      //puede que sea dataSource.data y no pruebaData
    .subscribe(datos => this.dataSource.data = datos as IPruebaCovidReport[],
      error => console.error(error))
      
    }
    
    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }

  applyFilter(event: Event) {
  
    
    console.log("Tabla");
    console.log(this.dataSource);
    console.log("target");
    console.log(event.target);    
    const filterValue = (event.target as HTMLInputElement).value;
    console.log("filterValue");
    console.log(filterValue);
    this.dataSource.filter = filterValue.trim().toLowerCase();
    console.log("this.dataSource.filter");
    console.log(this.dataSource.filter);
    console.log(this.pruebaDataLocal);

  }

}
