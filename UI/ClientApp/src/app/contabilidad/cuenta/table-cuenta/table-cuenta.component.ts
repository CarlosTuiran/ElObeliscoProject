import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { ICuenta } from '../cuenta.component';
import { CuentaService } from '../cuenta.service';

@Component({
  selector: 'app-table-cuenta',
  templateUrl: './table-cuenta.component.html',
  styleUrls: ['./table-cuenta.component.css']
})
export class TableCuentaComponent implements OnInit {

  cuentas!:ICuenta[];  
  displayedColumns: string[] = [
    'id',
    'codigo',
    'nombre',
    'tipo',
    'naturaleza',
    'options'];
  dataSource =new MatTableDataSource<ICuenta>(this.cuentas);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  
  constructor(private cuentasService: CuentaService, private router: Router, private activatedRoute: ActivatedRoute,
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
    this.cuentasService.getCuentas()
    .subscribe(cuentas => {this.dataSource.data = cuentas; console.log(this.dataSource.data);},
      error => console.error(error));

    this.cuentasService.refresh$.subscribe(() => {
      this.cuentasService.getCuentas()
        .subscribe(cuentas => this.dataSource.data = cuentas ,
          error => console.error(error));
    });
  }

  Eliminar(id: number) {
    this.cuentasService.deleteCuenta(id).
      subscribe(id => this.onDeleteSuccess(),
        error => this.alertService.error(error.error))
  }

  onDeleteSuccess() {
    this.router.navigate(["/cuentas"]);
    this.alertService.success("Eliminado exitoso");
  }

}
