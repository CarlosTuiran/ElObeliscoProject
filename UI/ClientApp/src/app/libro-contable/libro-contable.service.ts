import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { ILibroContable } from './libro-contable.component';

@Injectable({
  providedIn: 'root'
})
export class LibroContableService {

  private _refresh$ = new Subject<void>();
  apiURL = this.baseUrl + "api/LibroContable";
  constructor(public http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getLibroContable(): Observable<ILibroContable[]> {
    return this.http.get<ILibroContable[]>(this.apiURL);
  }

}
