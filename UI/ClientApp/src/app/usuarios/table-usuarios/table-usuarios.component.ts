import { Component, OnInit, Input } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import { IUsuario } from '../usuarios.component';

@Component({
  selector: 'app-table-usuarios',
  templateUrl: './table-usuarios.component.html',
  styleUrls: ['./table-usuarios.component.css']
})
export class TableUsuariosComponent  implements OnInit {
  
  @Input() usuarios:IUsuario[];
  const usuariosFalse: IUsuario[]={'nombre':'Carlos', 'empleadoId':2, 'tipo':'Usuario', 'password':'acceso'}
  displayedColumns: string[] = ['nombre', 'empleadoId', 'tipo'];
  public dataSource :MatTableDataSource;
  
  applyFilter(event: Event) {
    this.dataSource = new MatTableDataSource(this.usuarios);
    
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

  }
  ngOnInit() {
    this.dataSource = new MatTableDataSource(this.usuarios);
  }
}
