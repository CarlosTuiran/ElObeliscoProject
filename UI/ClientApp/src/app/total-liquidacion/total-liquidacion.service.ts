import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ITotalLiquidacion } from './total-liquidacion.component';

@Injectable({
  providedIn: 'root'
})
export class TotalLiquidacionService {

  apiURL = this.baseUrl + "api/TotalLiquidacion";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getTotalLiquidaciones(): Observable<ITotalLiquidacion[]> {
    return this.http.get<ITotalLiquidacion[]>(this.apiURL);
  }

  getTotalLiquidacion(idNomina: string, idEmpleado: number): Observable<ITotalLiquidacion> {
    return this.http.get<ITotalLiquidacion>(this.apiURL + '/' + idNomina + idEmpleado);
  }

  createTotalLiquidacion() {
    return this.http.get(this.apiURL);
  }
}
