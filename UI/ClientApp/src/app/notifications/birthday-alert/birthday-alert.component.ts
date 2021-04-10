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
          this.terceros=terceros;         
          console.log(this.terceros);          
        }
      }, error => console.error(error));
  }

}
