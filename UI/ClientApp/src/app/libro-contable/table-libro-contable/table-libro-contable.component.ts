import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { ILibroContable } from '../libro-contable.component';
import { LibroContableService } from '../libro-contable.service';

@Component({
  selector: 'app-table-libro-contable',
  templateUrl: './table-libro-contable.component.html',
  styleUrls: ['./table-libro-contable.component.css']
})
export class TableLibroContableComponent implements OnInit {

  libroContable!:ILibroContable[];  
  displayedColumns: string[] = [
    'codigo',
    'descripcion',
    'debe',          
    'haber',
    'origenId',
    'origenTipo',
    'fecha'
    ];
  dataSource =new MatTableDataSource<ILibroContable>(this.libroContable);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private libroContableService: LibroContableService, private router: Router,
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
    this.libroContableService.getLibroContable()
      .subscribe(libroContable => this.dataSource.data = libroContable,
        error => console.error(error));
  }

}
