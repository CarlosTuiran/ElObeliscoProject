import { Component, OnInit } from '@angular/core';
import { IProducto } from '../../productos/productos.component';
import { CantidadMinimaAlertService } from './cantidad-minima-alert.service';

@Component({
  selector: 'app-cantidad-minima-alert',
  templateUrl: './cantidad-minima-alert.component.html',
  styleUrls: ['./cantidad-minima-alert.component.scss']
})
export class CantidadMinimaAlertComponent implements OnInit {

  isAlertMin=false;
  productos:IProducto[];
  
  constructor(private cantidadMinimaAlertService: CantidadMinimaAlertService) { }
  
  ngOnInit() {
    this.cantidadMinimaAlertService.getAlerts()
      .subscribe((productos) => {
        if (productos.length == 0) {
          this.isAlertMin = false;          
        } else {
          this.isAlertMin = true;
        }
      }, error => console.error(error));
  }

}
