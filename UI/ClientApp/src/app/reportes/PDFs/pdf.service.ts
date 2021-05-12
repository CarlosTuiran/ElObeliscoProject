import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PdfService {

  apiURL = this.baseUrl + "api/CrearPDF";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get crearPDF() {
    return this.http.get(this.apiURL);
  }
}
