import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/login/auth.service';
import { UserInterface } from 'src/app/login/user-interface';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { isError } from 'util';
import { NgForm } from '@angular/forms/esm5/src/directives/ng_form';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router, private location: Location) { }
  private user: UserInterface = {
    user: '',
    password: ''
  };
  public isError = false;
  public hide=true;
  ngOnInit() { }
  onLogin(form: NgForm) {
    if (form.valid) {
      return this.authService
        .loginuser(this.user.user, this.user.password)
        .subscribe(
        data => {
          this.authService.setUser(data.user);
          const token = data.id;
          this.authService.setToken(token);
          this.router.navigate(['/']);
          location.reload();
          this.isError = false;
        },
        error => this.onIsError()
        );
    } else {
      this.onIsError();
    }
  }

  onIsError(): void {
    this.isError = true;
    setTimeout(() => {
      this.isError = false;
    }, 4000);
  }


}
