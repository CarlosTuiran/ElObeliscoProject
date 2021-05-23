import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { AlertService } from '../../../notifications/_services';
import { MarcaService } from '../../marca/marca.service';
import { ICategoria } from '../categoria.component';
import { CategoriaService } from '../categoria.service';
import { DialogoCategoriaComponent } from '../dialogo-categoria/dialogo-categoria.component';

@Component({
  selector: 'app-table-categoria',
  templateUrl: './table-categoria.component.html',
  styleUrls: ['./table-categoria.component.css']
})
export class TableCategoriaComponent implements OnInit {

  constructor(private categoriaService: CategoriaService, private router: Router,
    private alertService: AlertService, private dialog: MatDialog) { }

  categorias!: ICategoria[];
  displayedColumns: string[] = [
    'id',
    'nombre',
    'options'
  ];

  dataSource = new MatTableDataSource<ICategoria>(this.categorias);
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
    this.categoriaService.getCategorias()
      .subscribe(categorias => this.dataSource.data = categorias,
        error => this.alertService.error(error.error));

    this.categoriaService.refresh$.subscribe(() => {
      this.categoriaService.getCategorias()
        .subscribe(categorias => this.dataSource.data = categorias,
          error => this.alertService.error(error.error));
    });
  }

  Eliminar(id: number) {
    this.categoriaService.deleteCategoria(id).
      subscribe(id => this.onDeleteSuccess(),
        error => this.alertService.error(error.error))
  }

  openDialog(id: number) {
    const detallesVista = this.dialog.open(DialogoCategoriaComponent, {
      disableClose: false,
      autoFocus: true,
      width: 'auto'
    });
    detallesVista.componentInstance.idCategoria = id;
  }

  onDeleteSuccess() {
    this.alertService.success("Eliminado exitoso");
  }

}
