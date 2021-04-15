import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { AuthService } from '../../login/auth.service';
import { Roles } from '../../login/user-interface';

@Injectable({
  providedIn: 'root'
})
export class IsAdminGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }
  roleUser:string;
  canActivate(): boolean {
    this.authService.isAdmin$.subscribe(
      rol=>this.roleUser=rol, 
      error=>console.log(error));
      
    if (this.roleUser == "Admin") {
      return true;
    } else {
      this.router.navigate(['/']);  
      return false;
    }
  }
  
}
