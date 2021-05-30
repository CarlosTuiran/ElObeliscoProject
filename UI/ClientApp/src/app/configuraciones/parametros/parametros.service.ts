import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IParametros } from './parametros.component';

@Injectable({
  providedIn: 'root'
})
export class ParametrosService {

  apiURL = this.baseUrl + "api/Parametros";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  private _refresh$ = new Subject<void>();

  get refresh$() {
    return this._refresh$;
  }

  getParametros(): Observable<IParametros[]> {
    return this.http.get<IParametros[]>(this.apiURL);
  }

  getParametro(id: number): Observable<IParametros> {
    return this.http.get<IParametros>(this.apiURL + '/' + id);
  }

  createParametros(Parametros: IParametros): Observable<IParametros> {
    return this.http.post<IParametros>(this.apiURL, Parametros).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateParametros(Parametros: IParametros): Observable<IParametros> {
    return this.http.put<IParametros>(this.apiURL, Parametros);
  }

  deleteParametros(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + '/' + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
