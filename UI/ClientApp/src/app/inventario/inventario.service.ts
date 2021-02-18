import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IInventario } from './inventario.component';

@Injectable({
  providedIn: 'root'
})
export class InventarioService {

  apiURL = this.baseUrl + "api/Inventario";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getInventarios(): Observable<IInventario[]> {
    return this.http.get<IInventario[]>(this.apiURL);
  }
}
