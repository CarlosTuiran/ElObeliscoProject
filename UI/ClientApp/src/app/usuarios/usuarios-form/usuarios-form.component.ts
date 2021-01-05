import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { IUsuario } from '../usuarios.component';
import { UsuariosService } from '../usuarios.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IEmpleado } from 'src/app/empleados/empleados.component';
import { EmpleadosService } from 'src/app/empleados/empleados.service';
import { param } from 'jquery';
import { error } from 'protractor';
import { AlertService } from 'src/app/notifications/_services';

@Component({
  selector: 'app-usuarios-form',
  templateUrl: './usuarios-form.component.html',
  styleUrls: ['./usuarios-form.component.css']
})
export class UsuariosFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private usuariosService: UsuariosService,
    private empleadoService: EmpleadosService, private router: Router, 
    private alertService: AlertService,private activatedRoute: ActivatedRoute) { }

  modoEdicion: boolean = false;
  usuarioId: number;

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
          error =>{console.error(error); this.alertService.error(error.message);});

    this.activatedRoute.params.subscribe(params => {
      if (params["id"] == undefined) {
        return;
      }

      this.modoEdicion = true;
      this.usuarioId = params["id"];
      this.usuariosService.getUsuario(this.usuarioId.toString()).subscribe(usuario => this.cargarFormulario(usuario),
        error =>this.alertService.error(error.message));
    });
  }

  cargarFormulario(usuario: IUsuario) {
    this.formGroup.patchValue({
      nombre: usuario.nombre,
      empleadoId: usuario.empleadoId,
      password: usuario.password,
      passwordRep: usuario.password,
      tipo: usuario.tipo
    });
  }

  save() {
    let usuario: IUsuario = Object.assign({}, this.formGroup.value);
    console.table(usuario); //ver usuario por consola
    

    if (this.modoEdicion) {
      // edita un usuario
      usuario.empleadoId = this.usuarioId;
      this.usuariosService.updateUsuario(usuario)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    } else {
      // crea un usuario
      this.usuariosService.createUsuario(usuario)
        .subscribe(usuario => this.onSaveSuccess(),
          error => this.alertService.error(error.message));
    }
  }
  onSaveSuccess(){
    this.router.navigate(["/usuarios"]);
    this.alertService.success("Guardado Exitoso")
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
