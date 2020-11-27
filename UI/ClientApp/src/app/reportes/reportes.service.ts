import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReportesService {

  apiProductoURL = this.baseUrl + "api/Producto";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  Top10Productos(): Observable < any[] > {
    return this.http.get<any[]>(this.apiProductoURL + "/Top10Productos");
  }
}

