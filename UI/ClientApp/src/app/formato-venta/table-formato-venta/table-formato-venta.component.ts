import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../notifications/_services';
import { IFormatoVenta } from '../formato-venta.component';
import { FormatoVentaService } from '../formato-venta.service';

@Component({
  selector: 'app-table-formato-venta',
  templateUrl: './table-formato-venta.component.html',
  styleUrls: ['./table-formato-venta.component.css']
})
export class TableFormatoVentaComponent implements OnInit {

  formatosVenta!: IFormatoVenta[];
  displayedColumns: string[] = [
    'id',
    'nombre',
    'abreviacion',
    'metrica',
    'factorConversion',
    'options'];
  dataSource = new MatTableDataSource<IFormatoVenta>(this.formatosVenta);
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private formatoVentaService: FormatoVentaService, private router: Router, private activatedRoute: ActivatedRoute,
    private alertService: AlertService) { }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnInit() {
    this.formatoVentaService.getFormatosVenta()
      .subscribe(formatosVenta => this.dataSource.data = formatosVenta,
        error => console.error(error));
  }
}
