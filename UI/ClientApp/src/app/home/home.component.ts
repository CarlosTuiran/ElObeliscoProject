import { Component, OnInit } from '@angular/core';
import { AlertService } from '../notifications/_services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  constructor(private alertService: AlertService){}
  message="Bienvenido a el sistema de Informacion ElObelisco";
  ngOnInit() {
    this.alertService.info(this.message);
  }
}
