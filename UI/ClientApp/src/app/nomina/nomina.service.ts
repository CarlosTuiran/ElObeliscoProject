import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { INomina, IDeleteNomina } from './nomina.component';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NominaService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Nomina";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }

  getNominas(): Observable<INomina[]> {
    return this.http.get<INomina[]>(this.apiURL);
  }

  getNomina(idNomina: string, idEmpleado: number): Observable<INomina> {
    return this.http.get<INomina>(this.apiURL + '/' + idNomina + '/' + idEmpleado);
  }

  createNomina(nomina: INomina): Observable<INomina> {
    return this.http.post<INomina>(this.apiURL, nomina);
  }

  updateNomina(nomina: INomina): Observable<INomina> {
    return this.http.put<INomina>(this.apiURL + "/" + nomina.idEmpleado, nomina);
  }

  deleteNomina(idNomina: string, idEmpleado: number): Observable<IDeleteNomina> {
    return this.http.delete<IDeleteNomina>(this.apiURL + "/" + idNomina + "/" + idEmpleado.toString()).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
