import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IImpuesto } from './impuesto.component';

@Injectable({
  providedIn: 'root'
})
export class ImpuestoService {

  apiURL = this.baseUrl + "api/Impuesto";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  private _refresh$ = new Subject<void>();

  get refresh$() {
    return this._refresh$;
  }

  getImpuestos(): Observable<IImpuesto[]> {
    return this.http.get<IImpuesto[]>(this.apiURL);
  }

  getImpuesto(id: number): Observable<IImpuesto> {
    return this.http.get<IImpuesto>(this.apiURL + '/' + id);
  }

  createImpuesto(impuesto: IImpuesto): Observable<IImpuesto> {
    return this.http.post<IImpuesto>(this.apiURL, impuesto).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateImpuesto(impuesto: IImpuesto): Observable<IImpuesto> {
    return this.http.put<IImpuesto>(this.apiURL, impuesto).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  deleteImpuesto(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + '/' + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
