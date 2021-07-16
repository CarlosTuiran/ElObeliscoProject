import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IBodega } from './bodegas.component';

@Injectable({
  providedIn: 'root'
})
export class BodegasService {

  apiURL = this.baseUrl + "api/Bodega";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  private _refresh$ = new Subject<void>();

  get refresh$() {
    return this._refresh$;
  }

  getBodegas(): Observable<IBodega[]> {
    return this.http.get<IBodega[]>(this.apiURL);
  }

  getBodega(id: number): Observable<IBodega> {
    return this.http.get<IBodega>(this.apiURL + '/' + id);
  }

  createBodega(bodega: IBodega): Observable<IBodega> {
    return this.http.post<IBodega>(this.apiURL, bodega).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateBodega(bodega: IBodega): Observable<IBodega> {
    return this.http.put<IBodega>(this.apiURL, bodega);
  }

  deleteBodega(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + '/' + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
