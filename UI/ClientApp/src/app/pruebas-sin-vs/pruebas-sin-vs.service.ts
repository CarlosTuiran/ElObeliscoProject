import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PruebasSinVSService {

  constructor(private http:HttpClient) { }

  public  pruebaCovidReports(): Observable<any>{
    return this.http.get<any>("https://disease.sh/v3/covid-19/countries");
  }
  public fromCountry(country: string): Observable<any[]> {
    return this.pruebaCovidReports().pipe(map( data => data.country[country]));
  }
}


