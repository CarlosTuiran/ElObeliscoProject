import { Component, OnInit } from '@angular/core';
import { ITercero } from '../../terceros/terceros.component';
import { BirthdayAlertService } from './/birthday-alert.service';

@Component({
  selector: 'app-birthday-alert',
  templateUrl: './birthday-alert.component.html',
  styleUrls: ['./birthday-alert.component.css']
})
export class BirthdayAlertComponent implements OnInit {
  isAlertMin=false;
  nombresTerceros:string[]=[];
  terceros:ITercero[];

  constructor(private birthdayAlertService: BirthdayAlertService) { }

  ngOnInit() {
    this.birthdayAlertService.getAlerts()
      .subscribe((terceros) => {
        if (terceros.length == 0) {
          this.isAlertMin = false;          
        } else {
          this.isAlertMin = true;
          for(let item of terceros){
            this.nombresTerceros.push(item.nombre+ " "+ item.apellido);
          };
          console.log(this.nombresTerceros);          
        }
      }, error => console.error(error));
  }

}
