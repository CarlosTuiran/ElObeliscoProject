import { Component, OnInit } from '@angular/core';
import { AlertService } from '../notifications/_services';
import { ReportesService } from '../reportes/reportes.service';
import { ICard } from '../reportes/Tarjetas/card/card.component';
import { ICards } from '../reportes/Tarjetas/card/card.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  
  message = "Bienvenido a el sistema de Informacion ElObelisco";
  cards: ICard[] = [];
  constructor(private alertService: AlertService, private reportesService: ReportesService){
  
  }
  
  ngOnInit() {
    this.alertService.info(this.message);
    //*Consultar Cards  
    this.reportesService.ConsultasCartas()
    .subscribe(cardRta =>{
      for(let item of cardRta){
        console.log("item:" + item.rest.item1 );
      }

      this.cards=cardRta; console.log(this.cards);
    },
    error => this.alertService.error(error.message)
    );
    /*this.reportesService.AverageOrderValue()
    .subscribe(cardRta =>{
      //this.cards.push(cardRta);
      this.card1=cardRta; console.log(this.card1 +"-"+this.card1[0].value+"-"+this.card1['value']);
      this.reportesService.VentasMensuales()
      .subscribe(cardRta =>{
        this.cards.push(cardRta);
        this.reportesService.TotalOrdenes()
        .subscribe(cardRta =>{
          this.cards.push(cardRta);
          //this.cards = [cardRta1, cardRta2, cardRta3]
          console.log(this.cards[0].value, this.cards[0]['value']);
        },
        error => this.alertService.error(error.message));
      },
      error => this.alertService.error(error.message));
    },
      error => this.alertService.error(error.message));*/
  }
  
}

