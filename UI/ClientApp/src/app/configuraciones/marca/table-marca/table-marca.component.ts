import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { DialogoMarcaComponent } from '../dialogo-marca/dialogo-marca.component';
import { IMarca } from '../marca.component';
import { MarcaService } from '../marca.service';

@Component({
  selector: 'app-table-marca',
  templateUrl: './table-marca.component.html',
  styleUrls: ['./table-marca.component.css']
})
export class TableMarcaComponent implements OnInit {

  constructor(private marcaService: MarcaService, private router: Router,
    private alertService: AlertService, private dialog: MatDialog) { }

  marcas!: IMarca[];
  displayedColumns: string[] = [
    'id',
    'nombre',
    'options'
  ];
  dataSource = new MatTableDataSource<IMarca>(this.marcas);
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
    this.marcaService.getMarcas()
      .subscribe(marcas => this.dataSource.data = marcas,
        error => this.alertService.error(error.error));

    this.marcaService.refresh$.subscribe(() => {
      this.marcaService.getMarcas()
        .subscribe(marcas => this.dataSource.data = marcas,
          error => this.alertService.error(error.error));
    });
  }

  Eliminar(id: number) {
    this.marcaService.deleteMarca(id).
      subscribe(id => this.onDeleteSuccess(),
        error => this.alertService.error(error.error))
  }

  openDialog(id: number) {
    const detallesVista = this.dialog.open(DialogoMarcaComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
    detallesVista.componentInstance.idMarca = id;
  }

  onDeleteSuccess() {
    this.alertService.success("Eliminado exitoso");
  }

}
