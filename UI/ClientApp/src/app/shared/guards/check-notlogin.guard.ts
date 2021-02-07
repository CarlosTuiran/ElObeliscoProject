import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../../login/auth.service';
import { take, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class CheckNotloginGuard implements CanActivate {
  constructor(private authService: AuthService,  private router: Router) { }

  canActivate(): Observable<boolean> {
    this.router.navigate(['login']);
    return this.authService.isLogged.pipe(
      take(1),
      map((isLogged: boolean) => isLogged)
    );
  }
}

/**
@Injectable()
export class CanActivateAuthGuard implements CanActivate {

  constructor(private router: Router) { }

  canActivate(): boolean {
    let currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if (currentUser) {
      return true;
    } else {
      this.router.navigate(['/login/login']);
      return false;
    }
  }
}
 */
