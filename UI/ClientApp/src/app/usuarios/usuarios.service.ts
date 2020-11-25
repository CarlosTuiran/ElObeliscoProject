import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUsuario } from './usuarios.component';

@Injectable({
  providedIn: 'root'
}) 
export class UsuariosService {

  apiURL = this.baseUrl + "api/Usuario";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getUsuarios(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.apiURL);
  }

  getUsuario(usuarioId: string): Observable<IUsuario> {
    return this.http.get<IUsuario>(this.apiURL + '/' + usuarioId);
  }

  createUsuario(usuario: IUsuario): Observable<IUsuario> {
    return this.http.post<IUsuario>(this.apiURL, usuario);
  }

  updateUsuario(usuario: IUsuario): Observable<IUsuario> {
    return this.http.put<IUsuario>(this.apiURL + "/" + usuario.empleadoId, usuario);
  }

}
