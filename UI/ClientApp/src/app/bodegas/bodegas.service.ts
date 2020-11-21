import { Injectable } from '@angular/core';
import { IBodega } from './bodegas.component';

@Injectable({
  providedIn: 'root'
})
export class BodegasService {

  constructor() { }
  public bodegas: IBodega[]=[{'bodegaId':1, 'nombre':'BD1'}];

  getBodegas(){
    return this.bodegas
  }
}
