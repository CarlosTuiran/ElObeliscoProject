import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProducto, IDeleteProducto, IProducto2 } from './productos.component';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  apiURL = this.baseUrl + "api/Producto";
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getProductos(): Observable<IProducto2[]> {
    return this.http.get<IProducto2[]>(this.apiURL);
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

  deleteProducto(referencia: string): Observable<IDeleteProducto> {
    return this.http.put<IDeleteProducto>(this.apiURL + "/DeleteProducto" + "/" + referencia, referencia);
  }
}
