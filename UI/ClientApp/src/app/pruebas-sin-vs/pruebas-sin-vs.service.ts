import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PruebasSinVSService {

  constructor(private http:HttpClient) { }

  public  pruebaCovidReports(){
    return this.http.get("https://disease.sh/v3/covid-19/countries");
  }
  
}


