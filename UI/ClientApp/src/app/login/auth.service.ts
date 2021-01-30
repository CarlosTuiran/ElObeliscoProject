import { Inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import { catchError, map } from "rxjs/operators";
import { isNullOrUndefined } from "util";

import { Roles, User, UserResponse } from "src/app/login/user-interface";
import { AlertService } from "../notifications/_services";
import { BehaviorSubject, throwError } from "rxjs";
import { JwtHelperService } from "@auth0/angular-jwt";
import { Router } from "@angular/router";

const helper=new JwtHelperService();
@Injectable({
  providedIn: "root"
})

export class AuthService {
  apiURL = this.baseUrl + "api/Login";
  private loggedIn=new BehaviorSubject<boolean>(false);
  private role=new BehaviorSubject<Roles>(null);

  get isLogged():Observable<boolean>{
    return this.loggedIn.asObservable();
  }
  get isAdmin$():Observable<string>{
    return this.role.asObservable();
  }
  constructor(private htttp: HttpClient, private alertService: AlertService, private router: Router,
    @Inject('BASE_URL') private baseUrl: string) {
      this.checkToken();
    }
  
  
  login(authData: User): Observable<UserResponse | void> {
    return this.htttp
      .post<UserResponse>(this.apiURL, authData)
      .pipe(
        map((user: UserResponse) => {
          console.log('Resp', user);
          this.saveLocalStorage(user);
          this.loggedIn.next(true);
          this.role.next(user.rol)
          return user;
          
        }),
        catchError((err) => this.handlerError(err))
      );
  }

  logout():void{
    localStorage.removeItem('user');
    this.loggedIn.next(false);
    this.router.navigate(['/login']);
  }
  private checkToken():void{
    const user= JSON.parse(localStorage.getItem('user')) || null;//<--- si no existe user sera null
    if(user){
      const isExpired=helper.isTokenExpired(user.token);//<-el token expiro?
      //si expiro destruir el token 
      if(isExpired){
        this.logout();
      }else{
        this.loggedIn.next(true);
        this.role.next(user.rol)
      }
    }
    //isExpired ?this.logout():this.loggedIn.next(true);
    //console.log('Expiro el Token->', isExpired);
  }
  private saveLocalStorage(user: UserResponse):void{
    const {message, ...rest}=user;
    localStorage.setItem('user', JSON.stringify(rest));
  } 
  private handlerError(err):Observable<never>{
    let errorMessage = 'An errror occured retrienving data';
    if (err) {
      console.log("err=>",err);
      errorMessage = `Error: code ${err.message}`;
      this.alertService.error(err.error);
    }
    //window.alert(errorMessage);
    return throwError(errorMessage);
  }
/**
 * headers: HttpHeaders = new HttpHeaders({
    "Content-Type": "application/json"
  });
  registerUser(name: string, user: string, password: string) {
    //const url_api = "http://localhost:3000/api/Users";
    return this.htttp
      .post<UserInterface>(
        this.apiURL,//url_api,
        {
          name: name,
          user: user,
          password: password
        },
        { headers: this.headers }
      )
      .pipe(map(data => data));
  }

  loginuser(user: string, password: string): Observable<any> {
    //const url_api = "http://localhost:3000/api/Users/login?include=user";
    return this.htttp
      .post<UserInterface>(
        this.apiURL+'?include=user',//url_api,
        { user, password },
        { headers: this.headers }
      )
      .pipe(map(data => data));
  }

  setUser(user: UserInterface): void {
    let user_string = JSON.stringify(user);
    localStorage.setItem("currentUser", user_string);
  }

  setToken(token): void {
    localStorage.setItem("accessToken", token);
  }

  getToken() {
    return localStorage.getItem("accessToken");
  }

  getCurrentUser(): UserInterface {
    let user_string = localStorage.getItem("currentUser");
    if (!isNullOrUndefined(user_string)) {
      let user: UserInterface = JSON.parse(user_string);
      return user;
    } else {
      return null;
    }
  }

  logoutUser() {
    let accessToken = localStorage.getItem("accessToken");
    //const url_api = `http://localhost:3000/api/Users/logout?access_token=${accessToken}`;
    
    localStorage.removeItem("accessToken");
    localStorage.removeItem("currentUser");
    return this.htttp.post<UserInterface>(this.apiURL+'/logout?access_token=${accessToken}', { headers: this.headers });
  }
  */

}
