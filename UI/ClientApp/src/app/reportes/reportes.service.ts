import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IInterval } from './reportes.component';
import { ICard } from './Tarjetas/card/card.component';

@Injectable({
  providedIn: 'root'
})
export class ReportesService {

  apiProductoURL = this.baseUrl + "api/Producto";
  apiTerceroURL=this.baseUrl + "api/Tercero";
  apiEmpleadoURL = this.baseUrl + "api/Empleado";
  apiFacturaURL = this.baseUrl + "api/Factura";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  Top10Productos(): Observable < any[] > {
    return this.http.get<any[]>(this.apiProductoURL + "/Top10Productos");
  }
  Top10VentasProductos(): Observable < any[] > {
    return this.http.get<any[]>(this.apiProductoURL + "/Top10VentaProductos");
  }
  Top10VentasProductosInterval(Interval: IInterval): Observable<any[]> {
    return this.http.get<any[]>(this.apiProductoURL + "/Top10VentasProductosInterval/" + Interval.fechaInicio. toString() + "/" + Interval.fechaFin.toString());
  }
  Top10Proveedores(): Observable < any[] > {
    return this.http.get<any[]>(this.apiTerceroURL + "/Top10Proveedores");
  }
  Top10ProveedoresInterval(Interval: IInterval): Observable<any[]> {
    return this.http.get<any[]>(this.apiTerceroURL + "/Top10ProveedoresInterval/" + Interval.fechaInicio. toString() + "/" + Interval.fechaFin.toString());
  }
  Top10Clientes(): Observable < any[] > {
    return this.http.get<any[]>(this.apiTerceroURL + "/Top10Clientes");
  }
  Top10ClientesInterval(Interval: IInterval): Observable<any[]> {
    return this.http.get<any[]>(this.apiTerceroURL + "/Top10ClientesInterval/" + Interval.fechaInicio. toString() + "/" + Interval.fechaFin.toString());
  }
  Top10Empleados(): Observable < any[] > {
    return this.http.get<any[]>(this.apiEmpleadoURL + "/Top10Empleados");
  }
  Top10EmpleadosInterval(Interval: IInterval): Observable<any[]> {
    return this.http.get<any[]>(this.apiEmpleadoURL + "/Top10EmpleadosInterval/" + Interval.fechaInicio. toString() + "/" + Interval.fechaFin.toString());
  }
  TotalOrdenes(): Observable<ICard> {
    return this.http.get<ICard>(this.apiFacturaURL + "/TotalOrdenes");
  }
  VentasMensuales(): Observable<ICard> {
    return this.http.get<ICard>(this.apiFacturaURL + "/VentasMensuales");
  }
  AverageOrderValue(): Observable<ICard> {
    return this.http.get<ICard>(this.apiFacturaURL + "/AverageOrderValue");
  }
  ConsultasCartas():Observable<any[]> {
    return this.http.get<any[]>(this.apiFacturaURL + "/ConsultasCartas");
  }
}

