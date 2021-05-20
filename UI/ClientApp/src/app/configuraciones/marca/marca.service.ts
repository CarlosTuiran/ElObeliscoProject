import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { IMarca } from './marca.component';

@Injectable({
  providedIn: 'root'
})
export class MarcaService {

  apiURL = this.baseUrl + "api/Marca";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  private _refresh$ = new Subject<void>();

  get refresh$() {
    return this._refresh$;
  }

  getMarcas(): Observable<IMarca[]> {
    return this.http.get<IMarca[]>(this.apiURL);
  }

  getMarca(id: number): Observable<IMarca> {
    return this.http.get<IMarca>(this.apiURL + '/' + id);
  }

  createMarca(marca: IMarca): Observable<IMarca> {
    return this.http.post<IMarca>(this.apiURL, marca).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateMarca(marca: IMarca): Observable<IMarca> {
    return this.http.put<IMarca>(this.apiURL, marca);
  }

  deleteMarca(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + '/' + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
