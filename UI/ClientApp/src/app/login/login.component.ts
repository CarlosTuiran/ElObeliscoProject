import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/login/auth.service';
import { User } from 'src/app/login/user-interface';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { isError } from 'util';
import { NgForm } from '@angular/forms/esm5/src/directives/ng_form';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { from } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm=this.fb.group({
    usuario:['', [Validators.required]],
    password:['', [Validators.required]],
  });

  constructor(private authService: AuthService, private router: Router,
     private location: Location, private fb:FormBuilder) { }
  
     ngOnInit() {
    const userData:User={
      usuario: 'holasoyyo',
      password: '123456'
    };
    // this.authService.login(userData).subscribe(
    //   (res)=>console.log('Login')
    // );
   }
   onLogin():void{
     const formValue=this.loginForm.value;
     this.authService.login(formValue).subscribe((res)=>{
       if(res){
         this.router.navigate(['']);
       }
     })
   }
  // private user: UserInterface = {
  //   user: '',
  //   password: ''
  // };
  // public isError = false;
  // public hide=true;
  // onLogin(form: NgForm) {
  //   if (form.valid) {
  //     return this.authService
  //       .loginuser(this.user.user, this.user.password)
  //       .subscribe(
  //       data => {
  //         this.authService.setUser(data.user);
  //         const token = data.id;
  //         this.authService.setToken(token);
  //         this.router.navigate(['/']);
  //         location.reload();
  //         this.isError = false;
  //       },
  //       error => this.onIsError()
  //       );
  //   } else {
  //     this.onIsError();
  //   }
  // }

  // onIsError(): void {
  //   this.isError = true;
  //   setTimeout(() => {
  //     this.isError = false;
  //   }, 4000);
  // }


}
