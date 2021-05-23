import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { DialogoImpuestoComponent } from '../dialogo-impuesto/dialogo-impuesto.component';
import { IImpuesto } from '../impuesto.component';
import { ImpuestoService } from '../impuesto.service';

@Component({
  selector: 'app-table-impuesto',
  templateUrl: './table-impuesto.component.html',
  styleUrls: ['./table-impuesto.component.css']
})
export class TableImpuestoComponent implements OnInit {

  constructor(private impuestoService: ImpuestoService, private router: Router,
    private alertService: AlertService, private dialog: MatDialog) { }

  impuestos!: IImpuesto[];
  displayedColumns: string[] = [
    'id',
    'nombre',
    'tarifa',
    'tipo',
    'activo',
    'options'
  ];
  dataSource = new MatTableDataSource<IImpuesto>(this.impuestos);
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
    this.impuestoService.getImpuestos()
      .subscribe(impuestos => this.dataSource.data = impuestos,
        error => this.alertService.error(error.error));

    this.impuestoService.refresh$.subscribe(() => {
      this.impuestoService.getImpuestos()
        .subscribe(impuestos => this.dataSource.data = impuestos,
          error => this.alertService.error(error.error));
    });
  }

  Eliminar(id: number) {
    this.impuestoService.deleteImpuesto(id).
      subscribe(id => this.onDeleteSuccess(),
        error => this.alertService.error(error.error))
  }

  openDialog(id: number) {
    const detallesVista = this.dialog.open(DialogoImpuestoComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
    detallesVista.componentInstance.idImpuesto = id;
  }

  onDeleteSuccess() {
    this.alertService.success("Eliminado exitoso");
  }

}
