import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy } from '@angular/core';
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})

export class SidebarComponent implements OnDestroy {
  mobileQuery: MediaQueryList;

  fillerNav = [
    { name: "home", route: "", icon:"home" },
    { name: "Gestión de Usuarios", route: "usuarios", icon:"supervised_user_circle" },
    { name: "Gestión de Productos", route: "productos", icon: "assignment" },
    { name: "Gestión de Terceros", route: "terceros", icon: "local_shipping" },
    { name: "Facturacion", route: "facturas", icon: "shopping_bag" },
    { name: "Gestión de Empleados", route: "empleados", icon: "perm_contact_calendar" },
    { name: "Gestión de Nomina", route: "nominas", icon: "payments" },
    { name: "Liquidaciones", route: "liquidaciones", icon: "monetization_on" },
    { name: "Total Liquidaciones", route: "total-liquidaciones", icon: "monetization_on" },
    { name: "Reportes", route: "reportes", icon: "analytics" }

  ]
  

  private _mobileQueryListener: () => void;

  constructor(changeDetectorRef: ChangeDetectorRef, media: MediaMatcher) {
    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }

  shouldRun = true;
}


