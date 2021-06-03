import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ILiquidacion } from '../liquidacion.component';
import { LiquidacionService } from '../liquidacion.service';
import { Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';

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
    'nombreEmpleado',
    'mes',
    'anio',
    'sueldoOrdinario',
    'subTransporte',
    'totalDevengado',
    'totalDeducido',
    'totalPagar',
    'options'];
  dataSource =new MatTableDataSource<ILiquidacion>(this.liquidaciones);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private liquidacionesService: LiquidacionService, private router: Router,
    private alertService: AlertService, @Inject('BASE_URL') private baseUrl: string){}
  
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
    this.liquidacionesService.refresh$.subscribe(() => {
      this.liquidacionesService.getLiquidaciones()
        .subscribe(liquidaciones => this.dataSource.data = liquidaciones,
          error => console.error(error));
    });
  }

  Eliminar(idNomina: string, idEmpleado: number) {
    this.liquidacionesService.deleteLiquidacion(idNomina, idEmpleado).
      subscribe(idNomina => this.onDeleteSuccess(),
        error => this.alertService.error(error.error.message));
  }

  onDeleteSuccess() {
    this.router.navigate(["/liquidaciones"]);
    this.alertService.success("Eliminado exitoso");
  }

  printPDFLiquidacion(idEmpleado: number, idNomina: string) {
    var URL = this.baseUrl + "Liquidacion/" + idEmpleado + "/" + idNomina;
    window.open(URL, '_blank');
  }

}
