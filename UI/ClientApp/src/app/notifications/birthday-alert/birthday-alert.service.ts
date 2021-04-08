import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITercero } from '../../terceros/terceros.component';

@Injectable({
  providedIn: 'root'
})
export class BirthdayAlertService {

  apiURL = this.baseUrl + "api/BirthdayAlert";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAlerts(): Observable<ITercero[]> {
    return this.http.get<ITercero[]>(this.apiURL);
  }
}
