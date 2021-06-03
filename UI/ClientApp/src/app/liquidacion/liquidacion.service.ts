import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { ILiquidacion, IDeleteLiquidacion } from './liquidacion.component';
import { INominaPago } from '../nomina/nomina.component';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LiquidacionService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Liquidacion";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }

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
  deleteLiquidacion(idNomina: string, idEmpleado: number): Observable<IDeleteLiquidacion> {
    return this.http.delete<IDeleteLiquidacion>(this.apiURL + "/" + idNomina + "/" + idEmpleado.toString()).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  getPDFLiquidacion(idEmpleado: number, idNomina: string) {
    return this.http.get(this.apiURL + "/Liquidacion/" + idEmpleado + "/"+idNomina);
  }
}
