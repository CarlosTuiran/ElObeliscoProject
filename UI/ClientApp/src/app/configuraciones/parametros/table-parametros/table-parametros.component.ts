import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { IParametros } from '../parametros.component';
import { ParametrosService } from '../parametros.service';

@Component({
  selector: 'app-table-parametros',
  templateUrl: './table-parametros.component.html',
  styleUrls: ['./table-parametros.component.css']
})
export class TableParametrosComponent implements OnInit {

  constructor(private parametrosService: ParametrosService, private router: Router,
    private alertService: AlertService) { }

  parametross!: IParametros[];
  displayedColumns: string[] = [
    'id',
    'descripcion',
    'agrupacion',
    'valorNumerico',
    'valorTxt',
    'options'
  ];
  dataSource = new MatTableDataSource<IParametros>(this.parametross);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit() {
    this.parametrosService.getParametros()
      .subscribe(parametross => this.dataSource.data = parametross,
        error => this.alertService.error(error.error));

    this.parametrosService.refresh$.subscribe(() => {
      this.parametrosService.getParametros()
        .subscribe(parametross => this.dataSource.data = parametross,
          error => this.alertService.error(error.error));
    });
  }

  Eliminar(id: number) {
    this.parametrosService.deleteParametros(id).
      subscribe(id => this.onDeleteSuccess(),
        error => this.alertService.error(error.error))
  }

  //openDialog(id: number) {
  //  const detallesVista = this.dialog.open(DialogoparametrosComponent, {
  //    disableClose: false,
  //    autoFocus: true,
  //    width: 'auto'
  //  });
  //  detallesVista.componentInstance.idparametros = id;
  //}

  onDeleteSuccess() {
    this.alertService.success("Eliminado exitoso");
  }

}
