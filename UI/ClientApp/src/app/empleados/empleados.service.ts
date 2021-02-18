import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IEmpleado } from './empleados.component';
import { IDeleteEmpleado } from './empleados.component';

@Injectable({
  providedIn: 'root'
})
export class EmpleadosService {

  apiURL = this.baseUrl + "api/Empleado";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getEmpleados(): Observable<IEmpleado[]> {
    return this.http.get<IEmpleado[]>(this.apiURL);
  }

  getEmpleado(empleadoId: number): Observable<IEmpleado> {
    return this.http.get<IEmpleado>(this.apiURL + '/' + empleadoId);
  }

  createEmpleado(empleado: IEmpleado): Observable<IEmpleado> {
    return this.http.post<IEmpleado>(this.apiURL, empleado);
  }

  updateEmpleado(empleado: IEmpleado): Observable<IEmpleado> {
    return this.http.put<IEmpleado>(this.apiURL + "/" + empleado.idEmpleado.toString(), empleado);
  }

  deleteEmpleado(empleadoId: number): Observable<IDeleteEmpleado> {
    return this.http.put<IDeleteEmpleado>(this.apiURL  + "/DeleteEmpleado" + "/" +empleadoId.toString(), empleadoId);
  }
  
}
