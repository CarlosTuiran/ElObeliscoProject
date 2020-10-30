import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IMFactura } from './facturas.component';

@Injectable({
  providedIn: 'root'
})
export class FacturasService {
  
  apiURL = this.baseUrl + "api/Factura";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getFacturas(): Observable<IMFactura[]> {
    return this.http.get<IMFactura[]>(this.apiURL);
  }

  getFactura(FacturaId: string): Observable<IMFactura> {
    return this.http.get<IMFactura>(this.apiURL + '/' + FacturaId);
  }

  createFacturas(Factura: IMFactura): Observable<IMFactura> {
    return this.http.post<IMFactura>(this.apiURL, Factura);
  }

  updateFactura(Factura: IMFactura): Observable<IMFactura> {
    return this.http.put<IMFactura>(this.apiURL + "/" + Factura.idMfactura, Factura);
  }
  
}
