import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProducto } from './productos.component';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  apiURL = this.baseUrl + "api/Producto";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProductos(): Observable<IProducto[]> {
    return this.http.get<IProducto[]>(this.apiURL);
  }

  getProducto(productoId: string): Observable<IProducto> {
    return this.http.get<IProducto>(this.apiURL + '/' + productoId);
  }

  createProductos(producto: IProducto): Observable<IProducto> {
    return this.http.post<IProducto>(this.apiURL, producto);
  }

  updateProducto(producto: IProducto): Observable<IProducto> {
    return this.http.put<IProducto>(this.apiURL + "/" + producto.referencia, producto);
  }
}
