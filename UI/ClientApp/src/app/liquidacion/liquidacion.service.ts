import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ILiquidacion } from './liquidacion.component';
import { INominaPago } from '../nomina/nomina.component';

@Injectable({
  providedIn: 'root'
})
export class LiquidacionService {

  apiURL = this.baseUrl + "api/Liquidacion";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getLiquidaciones(): Observable<ILiquidacion[]> {
    return this.http.get<ILiquidacion[]>(this.apiURL);
  }

  getLiquidacion(idNomina: string, idEmpleado: number): Observable<ILiquidacion> {
    return this.http.get<ILiquidacion>(this.apiURL + '/' + idNomina + idEmpleado);
  }

  createLiquidacion(nomina: INominaPago): Observable<INominaPago> {
    return this.http.post<INominaPago>(this.apiURL, nomina);
  }

 /* updateNomina(nomina: ILiquidacion): Observable<ILiquidacion> {
    return this.http.put<ILiquidacion>(this.apiURL + "/" + nomina.idEmpleado.toString(), nomina);
  }*/
}