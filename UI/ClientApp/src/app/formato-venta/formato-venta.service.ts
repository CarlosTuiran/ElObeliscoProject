import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IFormatoVenta } from './formato-venta.component';

@Injectable({
  providedIn: 'root'
})
export class FormatoVentaService {

  apiURL = this.baseUrl + "api/FormatoVenta";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getFormatosVenta(): Observable<IFormatoVenta[]> {
    return this.http.get<IFormatoVenta[]>(this.apiURL);
  }
  getFormatoVenta(id: number): Observable<IFormatoVenta> {
    return this.http.get<IFormatoVenta>(this.apiURL + '/' + id);
  }
  //obtener los formatos de un producto especifico
  getFormatos(id: string): Observable<IFormatoVenta[]> {
    return this.http.get<IFormatoVenta[]>(this.apiURL + '/GetFormatos/' + id);
  }
  createFormatoVenta(formatVenta: IFormatoVenta): Observable<IFormatoVenta> {
    return this.http.post<IFormatoVenta>(this.apiURL, formatVenta);
  }
}
