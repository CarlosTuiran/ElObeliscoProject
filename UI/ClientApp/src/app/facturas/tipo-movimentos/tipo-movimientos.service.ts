import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITipoMovimiento } from './tipo-movimentos.component';

@Injectable({
  providedIn: 'root'
})
export class TipoMovimientosService {
  
  apiURL = this.baseUrl + "api/TipoMovimiento";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getTipoMovimientos(): Observable<ITipoMovimiento[]> {
    return this.http.get<ITipoMovimiento[]>(this.apiURL);
  }
  
}
