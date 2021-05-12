import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthService } from '../login/auth.service';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnInit, OnDestroy {
  mobileQuery: MediaQueryList;
  isAdmin = null;
  isLogged=false;

  private subscription: Subscription;

  fillerNavAdmin = [
    { name: "home", route: "", icon:"home" },
    { name: "Gestión de Usuarios", route: "usuarios", icon:"supervised_user_circle" },
    { name: "Gestión de Productos", route: "productos", icon: "assignment" },
    { name: "Inventario", route: "inventario", icon: "assignment" },
    { name: "Gestión de Terceros", route: "terceros", icon: "local_shipping" },
    { name: "Facturacion Venta", route: "facturasVenta", icon: "shopping_bag" },
    { name: "Facturacion Compra", route: "facturasCompra", icon: "shopping_bag" },
    { name: "Gestión de Empleados", route: "empleados", icon: "perm_contact_calendar" },
    { name: "Gestión de Nomina", route: "nominas", icon: "payments" },
    { name: "Liquidaciones", route: "liquidaciones", icon: "monetization_on" },
    { name: "Total Liquidaciones", route: "total-liquidaciones", icon: "monetization_on" },
    { name: "Reportes", route: "reportes", icon: "analytics" },
    { name: "Configuracion", route: "configuraciones", icon: "build" }
  ]

  fillerNavEmpleado = [
    { name: "home", route: "", icon: "home" },
    { name: "Gestión de Productos", route: "productos", icon: "assignment" },
    { name: "Inventario", route: "inventario", icon: "assignment" },
    { name: "Gestión de Terceros", route: "terceros", icon: "local_shipping" },
    { name: "Facturacion Venta", route: "facturasVenta", icon: "shopping_bag" },
    { name: "Facturacion Compra", route: "facturasCompra", icon: "shopping_bag" },
  ]
  

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher, private authService: AuthService) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.subscription = new Subscription();
  }
  ngOnInit() {
    this.subscription.add(
      this.authService.isAdmin$.subscribe((res) => (this.isAdmin = res))  
    );
    //this.subscription.add(
      this.authService.isLogged.subscribe((res) => (this.isLogged = res));
    //);
  }
  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
    this.subscription.unsubscribe();
  }
  changeRole():  void {
    this.isAdmin=!this.isAdmin;
  }
  shouldRun = true;
}


