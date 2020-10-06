import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { IUsuario } from '../usuarios.component';
import { UsuariosService } from '../usuarios.service';
import { Router } from '@angular/router';
import { IEmpleado } from 'src/app/empleados/empleados.component';
import { EmpleadosService } from 'src/app/empleados/empleados.service';

@Component({
  selector: 'app-usuarios-form',
  templateUrl: './usuarios-form.component.html',
  styleUrls: ['./usuarios-form.component.css']
})
export class UsuariosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuariosService: UsuariosService, 
    private empleadoService: EmpleadosService, private router: Router) { }
  
  formGroup = this.fb.group({
    nombre: ['', [Validators.required]],
    empleadoId: ['', [Validators.required]],
    password: new FormControl('', [Validators.minLength(6), Validators.required]),
    passwordRep: new FormControl(''),
    tipo: ['', [Validators.required]]
  });
  empleados: IEmpleado[];
  ngOnInit() {
    this.empleadoService.getEmpleados() //ACA EVENTUALMENTE SOLO DEBE LLAMAR UNA FUNCION QUE RETORNE LAS ID DE LOS EMPLEADOS SIN USUARIOS
        .subscribe(empleados => this.empleados = empleados,
        error => console.error(error));
  }

  save() {
    let usuario: IUsuario = Object.assign({}, this.formGroup.value);
    console.table(usuario); //ver usuario por consola
    this.usuariosService.createUsuario(usuario)
      .subscribe(usuario => this.onSaveSuccess(),
        error => console.error(error));
  }
  onSaveSuccess(){
    this.router.navigate(["/usuarios"]);
  }
  noequal1(){
    if(this.formGroup.controls['password'].value==this.formGroup.controls['passwordRep'].value){
      return false;
    }
    return true;
  }
  noequal(control: FormControl): { [s: string]: boolean } {
    let form: any = this;
    if (control.value !== form.controls['password'].value) {
      return {
        noiguales: true
      }
    }
    return null;
  }
  get nombre(){
    return this.formGroup.get('nombre');
  }
  get password(){
    return this.formGroup.get('password');
  }
  get passwordRep(){
    return this.formGroup.get('passwordRep');
  }
  get empleadoId(){
    return this.formGroup.get('empleadoId');
  }
  get tipo(){
    return this.formGroup.get('tipo');
  }
}
