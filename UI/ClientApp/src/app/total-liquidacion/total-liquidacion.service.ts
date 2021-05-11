import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { ITotalLiquidacion, IDTotalLiquidacion } from './total-liquidacion.component';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TotalLiquidacionService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/TotalLiquidacion";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get refresh$() {
    return this._refresh$;
  }
  getTotalLiquidaciones(): Observable<ITotalLiquidacion[]> {
    return this.http.get<ITotalLiquidacion[]>(this.apiURL);
  }

  getTotalLiquidacion(idNomina: string, idEmpleado: number): Observable<ITotalLiquidacion> {
    return this.http.get<ITotalLiquidacion>(this.apiURL + '/' + idNomina + idEmpleado);
  }

  createTotalLiquidacion(liquidacion: any): Observable<any>{
    return this.http.post(this.apiURL, liquidacion);
  }

  deleteTotalLiquidacion(idNomina: string): Observable<IDTotalLiquidacion> {
    return this.http.delete<IDTotalLiquidacion>(this.apiURL + "/" + idNomina).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
