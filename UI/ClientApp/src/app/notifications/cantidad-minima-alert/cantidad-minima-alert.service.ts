import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProducto } from '../../productos/productos.component';

@Injectable({
  providedIn: 'root'
})
export class CantidadMinimaAlertService {

  apiURL = this.baseUrl + "api/CantidadMinimaAlert";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAlerts(): Observable<IProducto[]> {
    return this.http.get<IProducto[]>(this.apiURL);
  }

  // getNomina(idNomina: string, idEmpleado: number): Observable<INomina> {
  //   return this.http.get<INomina>(this.apiURL + '/' + idNomina + '/' + idEmpleado);
  // }

  // createNomina(nomina: INomina): Observable<INomina> {
  //   return this.http.post<INomina>(this.apiURL, nomina);
  // }

  // updateNomina(nomina: INomina): Observable<INomina> {
  //   return this.http.put<INomina>(this.apiURL + "/" + nomina.idEmpleado.toString(), nomina);
  // }

}
