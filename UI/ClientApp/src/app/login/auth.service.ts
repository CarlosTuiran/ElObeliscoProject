import { Inject, Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs/internal/Observable";
import { map } from "rxjs/operators";
import { isNullOrUndefined } from "util";

import { UserInterface } from "src/app/login/user-interface";

@Injectable({
  providedIn: "root"
})

export class AuthService {
  apiURL = this.baseUrl + "api/Login";
  
  constructor(private htttp: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  headers: HttpHeaders = new HttpHeaders({
    "Content-Type": "application/json"
  });
  login():void{}
  logout():void{}
  private readToken():void{}
  private saveToken():void{}
  private handlerError():void{}
/**
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
