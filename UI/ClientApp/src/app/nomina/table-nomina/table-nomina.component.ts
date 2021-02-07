import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { INomina, INominaPago } from '../nomina.component';
import { NominaService } from '../nomina.service';
import { NominaComponent } from '../nomina.component';
import { LiquidacionService } from '../../liquidacion/liquidacion.service';
import { Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';


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
    'subTransporte',
    'options'];
    
    dataSource =new MatTableDataSource<INomina>(this.nominas);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private nominaService: NominaService, private liquidacionService: LiquidacionService, private router: Router,
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
    this.nominaService.getNominas()
    .subscribe(nominas => this.dataSource.data = nominas,
      error => this.alertService.error(error.message));

  }

  Pagar(idNomina: string, idEmpleado: number) {
    let nomina: INominaPago = { 'idEmpleado': idEmpleado };
    console.table(nomina);
    this.liquidacionService.createLiquidacion(nomina)
      .subscribe(usuario => this.onSaveSuccess(),
        error => this.alertService.error(error.message));
  }

  onSaveSuccess() {
    this.router.navigate(["/liquidaciones"]);
    this.alertService.success("Pagado Exitoso");
  }

}
