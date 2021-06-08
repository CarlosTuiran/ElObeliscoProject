import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IBodega } from '../bodegas.component';
import { BodegasService } from '../bodegas.service';
import { DialogoBodegasComponent } from '../dialogo-bodegas/dialogo-bodegas.component';

@Component({
  selector: 'app-table-bodegas',
  templateUrl: './table-bodegas.component.html',
  styleUrls: ['./table-bodegas.component.css']
})
export class TableBodegasComponent implements OnInit {

  constructor(private bodegasService: BodegasService, private router: Router,
    private alertService: AlertService, private dialog: MatDialog) { }

  bodegas!: IBodega[];
  displayedColumns: string[] = [
    'id',
    'nombre',
    'options'
  ];
  dataSource = new MatTableDataSource<IBodega>(this.bodegas);
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
    this.bodegasService.getBodegas()
      .subscribe(bodegas => this.dataSource.data = bodegas,
        error => this.alertService.error(error.error));

    this.bodegasService.refresh$.subscribe(() => {
      this.bodegasService.getBodegas()
        .subscribe(bodegas => this.dataSource.data = bodegas,
          error => this.alertService.error(error.error));
    });
  }

  Eliminar(id: number) {
    this.bodegasService.deleteBodega(id).
      subscribe(() => this.onDeleteSuccess(),
        error => this.alertService.error(error.error))
  }

  openDialog(id: number) {
    const detallesVista = this.dialog.open(DialogoBodegasComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
    detallesVista.componentInstance.idBodega = id;
  }

  onDeleteSuccess() {
    this.alertService.success("Eliminado exitoso");
  }
}
