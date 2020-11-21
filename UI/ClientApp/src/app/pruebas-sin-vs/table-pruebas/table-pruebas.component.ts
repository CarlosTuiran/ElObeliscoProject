import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { IPruebaCovidReport } from '../pruebas-sin-vs.component';
import { PruebasSinVSService } from '../pruebas-sin-vs.service';

@Component({
  selector: 'app-table-pruebas',
  templateUrl: './table-pruebas.component.html',
  styleUrls: ['./table-pruebas.component.css']
})
export class TablePruebasComponent implements OnInit, AfterViewInit {

  
  pruebaDataLocal!:IPruebaCovidReport[];
  displayedColumns: string[] = ['country', 'options'];
  dataSource=new MatTableDataSource<IPruebaCovidReport>(this.pruebaDataLocal);

  myControl = new FormControl();
  filteredOptions: Observable<IPruebaCovidReport[]>;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private service: PruebasSinVSService) { }
  
  ngOnInit() {
    this.service.pruebaCovidReports()      
    .subscribe(datos => this.dataSource.data = datos as IPruebaCovidReport[],
      error => console.error(error));
          
    }
    
    ngAfterViewInit() {
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
      this.dataSource.filter = filterValue.trim().toLowerCase(); 
  }
  

}
