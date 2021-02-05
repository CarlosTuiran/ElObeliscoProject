import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CheckNotloginGuard implements CanActivate {
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    return true;
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