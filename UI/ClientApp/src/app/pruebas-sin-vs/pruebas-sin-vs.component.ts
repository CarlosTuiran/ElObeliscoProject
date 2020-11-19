import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-pruebas-sin-vs',
  templateUrl: './pruebas-sin-vs.component.html',
  styleUrls: ['./pruebas-sin-vs.component.css']
})
export class PruebasSinVSComponent implements OnInit {

    
  constructor(private fb: FormBuilder) { }
  countryValue: string="";
  formGroup = this.fb.group({
    country:[this.countryValue, [Validators.required]]
  });

  ngOnInit() {
    
  }
  receiveMessage($event){
    this.country.setValue($event);
  }
  get country() {
    return this.formGroup.get('country');
  }
}

export interface IPruebaCovidReport{
country:string
}
