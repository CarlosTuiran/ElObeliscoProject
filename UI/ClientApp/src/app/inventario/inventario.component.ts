import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { InventarioService } from './inventario.service';
import { error } from '@angular/compiler/src/util';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertService } from '../notifications/_services';

@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  styleUrls: ['./inventario.component.css']
})
export class InventarioComponent implements OnInit {

  inventarios: IInventario[];
  inventario: any;
  constructor(private inventarioService: InventarioService, private router: Router,
    private alertService: AlertService) { }

  ngOnInit() {
    this.inventarioService.getInventarios()
      .subscribe(inventarios => this.inventarios = inventarios,
        error => this.alertService.error(error.message));
  }

}

export interface IInventario {
  referencia: string,
  descripcion: string,
  cantidad: number,
  precioVenta: number
}
