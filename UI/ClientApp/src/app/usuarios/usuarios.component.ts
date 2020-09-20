import { Component, OnInit } from '@angular/core';
import { UsuariosService } from './usuarios.service';
@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  //lista de Usuarios que tendra la pagina
  usuarios: IUsuario[];
  //inyeccion del servicio que se comunicara con la web api
  constructor(private usuariosService: UsuariosService) { }

  ngOnInit() {
    this.usuariosService.getUsuarios()
      //los usuarios que vengan desde el web service añadelos a la lista de usuarios de esta clase
      .subscribe(usuarios => this.usuarios = usuarios,
        error => console.error(error));
  }

}
export interface IUsuario {
   nombre: string, 
   password: string,
   empleadoId:number, 
   tipo: string  
}
