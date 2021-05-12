import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ICuenta } from './cuenta.component';

@Injectable({
  providedIn: 'root'
})
export class CuentaService {
  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/Cuenta";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  get refresh$() {
    return this._refresh$;
  }
  getCuentas(): Observable<ICuenta[]> {
    return this.http.get<ICuenta[]>(this.apiURL);
  }

  getCuenta(CuentaId: number): Observable<ICuenta> {
    return this.http.get<ICuenta>(this.apiURL + '/' + CuentaId);
  }

  createCuentas(Cuenta: ICuenta): Observable<ICuenta> {
    return this.http.post<ICuenta>(this.apiURL, Cuenta);
  }

  updateCuenta(Cuenta: ICuenta): Observable<ICuenta> {
    return this.http.put<ICuenta>(this.apiURL + "/" + Cuenta.id, Cuenta);
  }

  deleteCuenta(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + "/" + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
