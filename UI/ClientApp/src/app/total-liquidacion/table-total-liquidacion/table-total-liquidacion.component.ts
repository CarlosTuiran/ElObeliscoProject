import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ITotalLiquidacion } from '../total-liquidacion.component';
import { TotalLiquidacionService } from '../total-liquidacion.service';

@Component({
  selector: 'app-table-total-liquidacion',
  templateUrl: './table-total-liquidacion.component.html',
  styleUrls: ['./table-total-liquidacion.component.css']
})
export class TableTotalLiquidacionComponent implements OnInit {

  totalLiquidacions!:ITotalLiquidacion[];  
  displayedColumns: string[] = [
  'mes',
  'anio',
  'valorTotalNomina',
  'sena',
  'icbf',
  'comfacesar',
  'total',
  'nominaId',
  'options'];
  dataSource =new MatTableDataSource<ITotalLiquidacion>(this.totalLiquidacions);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor (private totalLiquidacionsService: TotalLiquidacionService){}
  
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();    
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.totalLiquidacionsService.getTotalLiquidaciones()
    .subscribe(totalLiquidacions => this.dataSource.data = totalLiquidacions,
      error => console.error(error));

  }


}
