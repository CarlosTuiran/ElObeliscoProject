import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit, OnDestroy {
  isLogged=false;
  isAdmin=null;
  //Cancelar subscripciones para ahorrar memoria 
  private subscription :Subscription;

  constructor(private authService: AuthService) {
    this.subscription = new Subscription();
  }

  ngOnInit() {
    this.subscription.add(
      this.authService.isLogged.subscribe((res) => (this.isLogged = res))      
    );
    this.subscription.add(
      this.authService.isAdmin$.subscribe((res) => (this.isAdmin = res))
    );
  }

  ngOnDestroy(): void{
    this.subscription.unsubscribe();
  }
  public Logout(){
    this.authService.logout();
  }
}
