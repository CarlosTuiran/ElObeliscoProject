import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { IUsuario } from '../usuarios.component';
import { UsuariosService } from '../usuarios.service';

@Component({
  selector: 'app-table-usuarios',
  templateUrl: './table-usuarios.component.html',
  styleUrls: ['./table-usuarios.component.css']
})
export class TableUsuariosComponent  implements OnInit {
  
  
  usuarios!:IUsuario[];  
  displayedColumns: string[] = ['nombre', 'empleadoId', 'tipo', 'options'];
  dataSource =new MatTableDataSource<IUsuario>(this.usuarios);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private usuariosService: UsuariosService){}
  
  applyFilter(event: Event) {
    //this.dataSource = new MatTableDataSource(this.usuarios);
    
    console.log("Tabla");
    console.log(this.dataSource);
    console.log("target");
    console.log(event.target);    
    const filterValue = (event.target as HTMLInputElement).value;
    console.log("filterValue");
    console.log(filterValue);
    this.dataSource.filter = filterValue.trim().toLowerCase();
    
    console.log(this.dataSource.filter);
    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.usuariosService.getUsuarios()
    .subscribe(usuarios => this.dataSource.data = usuarios,
      error => console.error(error));

  }
  
}
