import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITercero, IDeleteTercero } from './terceros.component';

@Injectable({
  providedIn: 'root'
})
export class TercerosService {

  apiURL = this.baseUrl + "api/Tercero";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getTerceros(): Observable<ITercero[]> {
    return this.http.get<ITercero[]>(this.apiURL);
  }

  getTercerostipoTercero(tipoTercero: string): Observable<ITercero[]> {
    return this.http.get<ITercero[]>(this.apiURL + 'TipoMovimiento/' + tipoTercero);
  }

  getTercero(terceroId: string): Observable<ITercero> {
    return this.http.get<ITercero>(this.apiURL + '/' + terceroId);
  }

  createTercero(tercero: ITercero): Observable<ITercero> {
    return this.http.post<ITercero>(this.apiURL, tercero);
  }

  updateTercero(tercero: ITercero): Observable<ITercero> {
    return this.http.put<ITercero>(this.apiURL + "/" + tercero.nit, tercero);
  }

  deleteTerceros(nit: string): Observable<IDeleteTercero> {
    return this.http.put<IDeleteTercero>(this.apiURL + "/DeleteTercero" + "/" + nit, nit);
  }
}
