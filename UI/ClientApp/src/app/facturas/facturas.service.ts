import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IDFactura, IMFactura } from './facturas.component';

@Injectable({
  providedIn: 'root'
})
export class FacturasService {
  
  apiURL = this.baseUrl + "api/Factura";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getFacturas(): Observable<IMFactura[]> {
    return this.http.get<IMFactura[]>(this.apiURL);
  }
  
  getDFacturas(FacturaId: number): Observable<IDFactura[]> {
    return this.http.get<IDFactura[]>(this.apiURL+'/'+FacturaId);
  }

  getFactura(FacturaId: string): Observable<IDFactura> {
    return this.http.get<IDFactura>(this.apiURL + '/' + FacturaId);
  }

  createFacturas(Factura: IMFactura): Observable<IMFactura> {
    return this.http.post<IMFactura>(this.apiURL, Factura);
  }
  //para calcular el subtotal en el servidor
  precreateFacturas(Factura: IMFactura): Observable<IMFactura> {
    return this.http.post<IMFactura>(this.apiURL+ '/preCreateFacturas' , Factura);
  }
  updateFactura(Factura: IMFactura): Observable<IMFactura> {
    return this.http.put<IMFactura>(this.apiURL + "/" + Factura.idMfactura, Factura);
  }
  
}
