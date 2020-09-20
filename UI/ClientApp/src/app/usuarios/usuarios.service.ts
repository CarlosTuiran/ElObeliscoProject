import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IUsuario } from './usuarios.component';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  apiURL = this.baseUrl + "api/UsuarioController";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getUsuarios(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(this.apiURL);
  }
}
