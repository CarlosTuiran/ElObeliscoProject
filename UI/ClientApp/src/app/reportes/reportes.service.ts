import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportesService {

  apiProductoURL = this.baseUrl + "api/Producto";
  apiTerceroURL=this.baseUrl + "api/Tercero";
  apiEmpleadoURL=this.baseUrl + "api/Empleado";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  Top10Productos(): Observable < any[] > {
    return this.http.get<any[]>(this.apiProductoURL + "/Top10Productos");
  }
  Top10VentasProductos(): Observable < any[] > {
    return this.http.get<any[]>(this.apiProductoURL + "/TopVentaProductos");
  }
  Top10Proveedores(): Observable < any[] > {
    return this.http.get<any[]>(this.apiTerceroURL + "/Top10Proveedores");
  }
  Top10Clientes(): Observable < any[] > {
    return this.http.get<any[]>(this.apiTerceroURL + "/Top10Clientes");
  }
  Top10Empleados(): Observable < any[] > {
    return this.http.get<any[]>(this.apiEmpleadoURL + "/Top10Empleados");
  }
}

