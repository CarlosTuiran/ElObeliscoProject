import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmpleado } from './empleados.component';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  
  apiURL = this.baseUrl + "api/Empleado";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEmpleados(): Observable<IEmpleado[]> {
    return this.http.get<IEmpleado[]>(this.apiURL);
  }
  /*getEmpleadosId(): Observable<int[]> {
    return this.http.get<IEmpleado[]>(this.apiURL);
  }Una posible forma de solo tomar la lista de id de empleado */
}
