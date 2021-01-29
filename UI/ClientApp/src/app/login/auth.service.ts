import { Inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import { catchError, map } from "rxjs/operators";
import { isNullOrUndefined } from "util";

import { User, UserResponse } from "src/app/login/user-interface";
import { AlertService } from "../notifications/_services";
import { BehaviorSubject, throwError } from "rxjs";
import { JwtHelperService } from "@auth0/angular-jwt";

const helper=new JwtHelperService();
@Injectable({
  providedIn: "root"
})

export class AuthService {
  apiURL = this.baseUrl + "api/Login";
  private loggedIn=new BehaviorSubject<boolean>(false);
  get isLogged():Observable<boolean>{
    return this.loggedIn.asObservable();
  }
  constructor(private htttp: HttpClient, private alertService: AlertService
    ,@Inject('BASE_URL') private baseUrl: string) {
      this.checkToken();
    }
  
  
  login(authData: User): Observable<UserResponse | void> {
    return this.htttp
      .post<UserResponse>(this.apiURL, authData)
      .pipe(
        map((user: UserResponse) => {
          console.log('Resp', user);
          //save token
          this.saveToken(user.token);
          this.loggedIn.next(true);
          return user;
          /*this.saveLocalStorage(user);
          this.user.next(user);
          return user;*/
        }),
        catchError((err) => this.handlerError(err))
      );
  }

  logout():void{
    localStorage.removeItem('token');
    this.loggedIn.next(false);
  }
  private checkToken():void{
    const userToken=localStorage.getItem('token');
    const isExpired=helper.isTokenExpired(userToken);//<-el token expiro?
    isExpired ?this.logout():this.loggedIn.next(true);//si expiro destruir el token 
    console.log('Expiro el Token->', isExpired);
  }
  private saveToken(token:string):void{
    localStorage.setItem('token',token)
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
