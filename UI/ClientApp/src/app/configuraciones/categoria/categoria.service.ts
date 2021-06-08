import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ICategoria } from './categoria.component';

@Injectable({
  providedIn: 'root'
})
export class CategoriaService {
  apiURL = this.baseUrl + "api/Categoria";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  private _refresh$ = new Subject<void>();

  get refresh$() {
    return this._refresh$;
  }

  getCategorias(): Observable<ICategoria[]> {
    return this.http.get<ICategoria[]>(this.apiURL);
  }

  getCategoria(id: number): Observable<ICategoria> {
    return this.http.get<ICategoria>(this.apiURL + '/' + id);
  }

  createCategoria(marca: ICategoria): Observable<ICategoria> {
    return this.http.post<ICategoria>(this.apiURL, marca).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  updateCategoria(marca: ICategoria): Observable<ICategoria> {
    return this.http.put<ICategoria>(this.apiURL, marca).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }

  deleteCategoria(id: number): Observable<number> {
    return this.http.delete<number>(this.apiURL + '/' + id).
      pipe(tap(() => {
        this._refresh$.next();
      }));
  }
}
