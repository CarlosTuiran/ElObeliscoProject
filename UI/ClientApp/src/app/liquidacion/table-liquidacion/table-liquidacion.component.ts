import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ILiquidacion } from '../liquidacion.component';
import { LiquidacionService } from '../liquidacion.service';

@Component({
  selector: 'app-table-liquidacion',
  templateUrl: './table-liquidacion.component.html',
  styleUrls: ['./table-liquidacion.component.css']
})
export class TableLiquidacionComponent implements OnInit {

  liquidaciones!:ILiquidacion[];  
  displayedColumns: string[] = [
  'nominaId',
  'idEmpleado',
  'mes',
  'anio',
  'sueldoOrdinario',
  'subTransporte',
  'totalDevengado',
  'salud',
  'pension',
  'totalDeducido',
  'totalPagar',
    'options'];
  dataSource =new MatTableDataSource<ILiquidacion>(this.liquidaciones);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private liquidacionesService: LiquidacionService){}
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.liquidacionesService.getLiquidaciones()
    .subscribe(liquidaciones => this.dataSource.data = liquidaciones,
      error => console.error(error));

  }


}
