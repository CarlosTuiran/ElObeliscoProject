import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { IPruebaCovidReport } from '../pruebas-sin-vs.component';
import { PruebasSinVSService } from '../pruebas-sin-vs.service';

@Component({
  selector: 'app-select-prueba',
  templateUrl: './select-prueba.component.html',
  styleUrls: ['./select-prueba.component.css']
})
export class SelectPruebaComponent implements OnInit {

  keyword='country';
  data: IPruebaCovidReport[];
  country:string;
  @Output() messageEvent= new EventEmitter<string>();
  constructor(private service: PruebasSinVSService) { }

  ngOnInit() {
    this.service.pruebaCovidReports()      
    .subscribe(datos => this.data = datos as IPruebaCovidReport[],
      error => console.error(error));
      
  }

  selectEvent(item: any) {
    this.messageEvent.emit(item.country);
    
  } 
  
}
