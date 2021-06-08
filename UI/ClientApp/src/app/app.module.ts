import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DataTablesModule } from 'angular-datatables';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { UsuariosService } from './usuarios/usuarios.service';
import { TableUsuariosComponent } from './usuarios/table-usuarios/table-usuarios.component';
import { UsuariosFormComponent } from './usuarios/usuarios-form/usuarios-form.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { EmpleadosService } from './empleados/empleados.service';
import { SidebarComponent } from './sidebar/sidebar.component';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import {ConfirmEqualValidatorDirective} from './usuarios/usuarios-form/confirm-equal-validator.directive';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { DemoMaterialModule } from './material-module';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import {AutocompleteLibModule} from 'angular-ng-autocomplete'; 
//import { ThemeService, THEME_CONFIG } from '@bcodes/ngx-theme-service';

import { ProductosComponent } from './productos/productos.component';
import { EmpleadosFormComponent } from './empleados/empleados-form/empleados-form.component';
import { ProductosFormComponent } from './productos/productos-form/productos-form.component';
import { TercerosComponent } from './terceros/terceros.component';
import { TercerosFormComponent } from './terceros/terceros-form/terceros-form.component';
import { TercerosService} from './terceros/terceros.service';
import { FacturasComponent } from './facturas/facturas.component'; 
import { FacturasService} from './facturas/facturas.service';
import { FacturasFormComponent } from './facturas/facturas-form/facturas-form.component';
import { TipoMovimentosComponent } from './facturas/tipo-movimentos/tipo-movimentos.component';
import { TipoMovimientosService } from './facturas/tipo-movimentos/tipo-movimientos.service';
import { BodegasComponent} from './bodegas/bodegas.component';
import { BodegasService} from './bodegas/bodegas.service';
import { PromocionesComponent} from './promociones/promociones.component';
import { PromocionesService} from './promociones/promociones.service';
import { NominaComponent } from './nomina/nomina.component';
import { NominaService } from './nomina/nomina.service';
import { NominaFormComponent } from './nomina/nomina-form/nomina-form.component';
import { TotalLiquidacionComponent } from './total-liquidacion/total-liquidacion.component';
import { TotalLiquidacionService } from './total-liquidacion/total-liquidacion.service';
import { LiquidacionComponent } from './liquidacion/liquidacion.component';
import { LiquidacionService } from './liquidacion/liquidacion.service';

//import { NgxMatDatetimePickerModule, NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import {MatDatepickerModule ,MatInputModule,MatNativeDateModule} from '@angular/material';
import { ChartsModule, ThemeService } from 'ng2-charts';
import { SelectorEmpleadoComponent } from './selector-empleado/selector-empleado.component';
import { DatePipe } from '@angular/common';
import { PruebasSinVSComponent } from './pruebas-sin-vs/pruebas-sin-vs.component';
import { PruebasSinVSService } from './pruebas-sin-vs/pruebas-sin-vs.service';
import { TablePruebasComponent } from './pruebas-sin-vs/table-pruebas/table-pruebas.component';
import { SelectPruebaComponent } from './pruebas-sin-vs/select-prueba/select-prueba.component';
import { PruebapiechartComponent } from './pruebas-sin-vs/pruebapiechart/pruebapiechart.component';
import { EmpleadoSelectComponent } from './empleados/empleado-select/empleado-select.component';
import { TercerosSelectComponent } from './terceros/terceros-select/terceros-select.component';
import { ProductosSelectComponent } from './productos/productos-select/productos-select.component';
import { PromocionesSelectComponent } from './promociones/promociones-select/promociones-select.component';
import { TipoMovimientoSelectComponent } from './tipoMovimiento/tipo-movimiento-select/tipo-movimiento-select.component';
import { TableFacturasComponent } from './facturas/table-facturas/table-facturas.component';
import { TableProductosComponent } from './productos/table-productos/table-productos.component';
import { TableTercerosComponent } from './terceros/table-terceros/table-terceros.component';
import { TableEmpleadosComponent } from './empleados/table-empleados/table-empleados.component';
import { TableNominaComponent } from './nomina/table-nomina/table-nomina.component';
import { TableLiquidacionComponent } from './liquidacion/table-liquidacion/table-liquidacion.component';
import { TablePromocionesComponent } from './promociones/table-promociones/table-promociones.component';
import { InventarioPieChartComponent } from './reportes/inventario-pie-chart/inventario-pie-chart.component';
import { ReportesComponent } from './reportes/reportes.component';
import { TableTotalLiquidacionComponent } from './total-liquidacion/table-total-liquidacion/table-total-liquidacion.component';
// import alert service and component
import { AlertComponent } from './notifications/_directives/index';
import { AlertService } from './notifications/_services/index';
import { LoginComponent } from './login/login.component';
import { CheckLoginGuard } from './shared/guards/check-login.guard';
import { CheckNotloginGuard } from './shared/guards/check-notlogin.guard';
import { PerfilComponent } from './login/perfil/perfil.component';
import { InventarioComponent } from './inventario/inventario.component';
import { TableInventarioComponent } from './inventario/table-inventario/table-inventario.component';
import { InventarioService } from './inventario/inventario.service';
import { CantidadMinimaAlertComponent } from './notifications/cantidad-minima-alert/cantidad-minima-alert.component';
import { TableDetallesComponent } from './facturas/table-detalles/table-detalles.component';
import { DialogoCrearFacturaComponent } from './facturas/facturas-form/dialogo-crear-factura/dialogo-crear-factura.component';
import { TopVentaProductosPieChartComponent } from './reportes/top-venta-productos-pie-chart/top-venta-productos-pie-chart.component';
import { TopProveedoresPieChartComponent } from './reportes/top-proveedores-pie-chart/top-proveedores-pie-chart.component';
import { TopClientesPieChartComponent } from './reportes/top-clientes-pie-chart/top-clientes-pie-chart.component';
import { TopEmpleadosPieChartComponent } from './reportes/top-empleados-pie-chart/top-empleados-pie-chart.component';
import { CardComponent } from './reportes/Tarjetas/card/card.component';
import { BirthdayAlertComponent } from './notifications/birthday-alert/birthday-alert.component';
import { BirthdayAlertService } from './notifications/birthday-alert/birthday-alert.service';
import { DialogoTipoTerceroComponent } from './facturas/table-facturas/dialogo-tipo-tercero/dialogo-tipo-tercero.component';
import { FlujoVentasLineChartComponent } from './reportes/flujo-ventas-line-chart/flujo-ventas-line-chart.component';
import { FlujoVentasBarraChartComponent } from './reportes/flujo-ventas-barra-chart/flujo-ventas-barra-chart.component';
import { IsAdminGuard } from './shared/guards/is-admin.guard';
import { FormatoVentaComponent } from './formato-venta/formato-venta.component';
import { FormFormatoVentaComponent } from './formato-venta/form-formato-venta/form-formato-venta.component';
import { TableFormatoVentaComponent } from './formato-venta/table-formato-venta/table-formato-venta.component';
import { ContabilidadComponent } from './contabilidad/contabilidad.component';
import { ConfiguracionesComponent } from './configuraciones/configuraciones.component';
import { CardFormatoVentaComponent } from './formato-venta/card-formato-venta/card-formato-venta.component';
import { CuentaComponent } from './contabilidad/cuenta/cuenta.component';
import { FormCuentaComponent } from './contabilidad/cuenta/form-cuenta/form-cuenta.component';
import { TableCuentaComponent } from './contabilidad/cuenta/table-cuenta/table-cuenta.component';
import { CuentaService } from './contabilidad/cuenta/cuenta.service';
import { MarcaComponent } from './configuraciones/marca/marca.component';
import { CategoriaComponent } from './configuraciones/categoria/categoria.component';
import { TableMarcaComponent } from './configuraciones/marca/table-marca/table-marca.component';
import { DialogoMarcaComponent } from './configuraciones/marca/dialogo-marca/dialogo-marca.component';
import { TableCategoriaComponent } from './configuraciones/categoria/table-categoria/table-categoria.component';
import { DialogoCategoriaComponent } from './configuraciones/categoria/dialogo-categoria/dialogo-categoria.component';
import { SelectCuentaComponent } from './contabilidad/cuenta/select-cuenta/select-cuenta.component';
import { ImpuestoComponent } from './contabilidad/impuesto/impuesto.component';
import { TableImpuestoComponent } from './contabilidad/impuesto/table-impuesto/table-impuesto.component';
import { DialogoImpuestoComponent } from './contabilidad/impuesto/dialogo-impuesto/dialogo-impuesto.component';
import { ParametrosComponent } from './configuraciones/parametros/parametros.component';
import { TableParametrosComponent } from './configuraciones/parametros/table-parametros/table-parametros.component';
import { FormParametrosComponent } from './configuraciones/parametros/form-parametros/form-parametros.component';
import { LibroContableComponent } from './libro-contable/libro-contable.component';
import { TableLibroContableComponent } from './libro-contable/table-libro-contable/table-libro-contable.component';
import { DialogoBodegasComponent } from './bodegas/dialogo-bodegas/dialogo-bodegas.component';
import { TableBodegasComponent } from './bodegas/table-bodegas/table-bodegas.component';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsuariosComponent,
    UsuariosFormComponent,
    ConfirmEqualValidatorDirective,
    SidebarComponent,
    EmpleadosComponent,
    EmpleadosFormComponent,
    ProductosComponent,
    ProductosFormComponent,
    TercerosComponent,
    TercerosFormComponent,
    FacturasComponent,
    FacturasFormComponent,
    TipoMovimentosComponent,
    BodegasComponent,
    PromocionesComponent,
    NominaComponent,
    NominaFormComponent,
    TotalLiquidacionComponent,
    LiquidacionComponent,
    SelectorEmpleadoComponent,
    TableUsuariosComponent,
    PruebasSinVSComponent,
    TablePruebasComponent,
    SelectPruebaComponent,
    PruebapiechartComponent,
    EmpleadoSelectComponent,
    TercerosSelectComponent,
    ProductosSelectComponent,
    PromocionesSelectComponent,
    TipoMovimientoSelectComponent,
    TableFacturasComponent,
    TableProductosComponent,
    TableTercerosComponent,
    TableEmpleadosComponent,
    TableNominaComponent,
    TableLiquidacionComponent,
    TablePromocionesComponent,
    InventarioPieChartComponent,
    ReportesComponent,
    TableTotalLiquidacionComponent,
    AlertComponent,
    LoginComponent,
    PerfilComponent,
    InventarioComponent,
    TableInventarioComponent,
    CantidadMinimaAlertComponent,
    TableDetallesComponent,
    DialogoCrearFacturaComponent,
    TopVentaProductosPieChartComponent,
    TopProveedoresPieChartComponent,
    TopClientesPieChartComponent,
    TopEmpleadosPieChartComponent,
    CardComponent,
    BirthdayAlertComponent,
    DialogoTipoTerceroComponent,
    FlujoVentasLineChartComponent,
    FlujoVentasBarraChartComponent,
    FormatoVentaComponent,
    FormFormatoVentaComponent,
    TableFormatoVentaComponent,
    ContabilidadComponent,
    ConfiguracionesComponent,
    CardFormatoVentaComponent,
    CuentaComponent,
    FormCuentaComponent,
    TableCuentaComponent,
    MarcaComponent,
    CategoriaComponent,
    TableMarcaComponent,
    DialogoMarcaComponent,
    TableCategoriaComponent,
    DialogoCategoriaComponent,
    SelectCuentaComponent,
    ImpuestoComponent,
    TableImpuestoComponent,
    DialogoImpuestoComponent,
    ParametrosComponent,
    TableParametrosComponent,
    FormParametrosComponent,
    LibroContableComponent,
    TableLibroContableComponent,
    DialogoBodegasComponent,
    TableBodegasComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    NgxMatSelectSearchModule,    
    AutocompleteLibModule,
    ChartsModule,
    CommonModule,
    DataTablesModule, MatDatepickerModule, MatNativeDateModule,
    MatFormFieldModule,
    MatInputModule,
    //NgxMatDatetimePickerModule, NgxMatTimepickerModule,
    //ACA SE REGISTRAN TODOS LOS COMPONENTES
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate:[CheckNotloginGuard] },
      { path: 'usuarios', component: UsuariosComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'usuarios-crear', component: UsuariosFormComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'usuarios-editar/:id', component: UsuariosFormComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'productos', component: ProductosComponent, canActivate: [CheckNotloginGuard] },
      { path: 'productos-crear', component: ProductosFormComponent, canActivate: [CheckNotloginGuard] },
      { path: 'productos-editar/:id', component: ProductosFormComponent, canActivate: [CheckNotloginGuard] },
      { path: 'terceros', component: TercerosComponent, canActivate: [CheckNotloginGuard] },
      { path: 'terceros-crear', component: TercerosFormComponent, canActivate: [CheckNotloginGuard] },
      { path: 'terceros-editar/:id', component: TercerosFormComponent, canActivate: [CheckNotloginGuard] },
      { path: 'facturasVenta', component: FacturasComponent, canActivate: [CheckNotloginGuard] },
      { path: 'facturasCompra', component: FacturasComponent, canActivate: [CheckNotloginGuard] },
      { path: 'facturas-crearVenta', component: FacturasFormComponent, canActivate: [CheckNotloginGuard] },
      { path: 'facturas-crearCompra', component: FacturasFormComponent, canActivate: [CheckNotloginGuard] },
      { path: 'empleados', component: EmpleadosComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'empleados-crear', component: EmpleadosFormComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'empleados-editar/:id', component: EmpleadosFormComponent, canActivate: [IsAdminGuard] },
      { path: 'nominas', component: NominaComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'nominas-crear', component: NominaFormComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'nominas-editar/:id/:idN', component: NominaFormComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'liquidaciones', component: LiquidacionComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'total-liquidaciones', component: TotalLiquidacionComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'pruebasSinVS', component: PruebasSinVSComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'reportes', component: ReportesComponent, canActivate: [IsAdminGuard, CheckNotloginGuard] }, 
      { path: 'login', component: LoginComponent, canActivate: [CheckLoginGuard] },
      { path: 'inventario', component: InventarioComponent, canActivate: [CheckNotloginGuard] },
      { path: 'formatoVenta', component: FormatoVentaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'formatoVenta-crear', component: FormFormatoVentaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'cuentas', component: CuentaComponent, canActivate: [CheckNotloginGuard, IsAdminGuard] },
      { path: 'cuenta-crear', component: FormCuentaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'cuenta-editar/:id', component: FormCuentaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'configuraciones', component: ConfiguracionesComponent, canActivate: [CheckNotloginGuard] },
      { path: 'marcas', component: MarcaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'categorias', component: CategoriaComponent, canActivate: [CheckNotloginGuard] },
      { path: 'parametros', component: ParametrosComponent, canActivate: [CheckNotloginGuard] },
      { path: 'parametros-crear', component: FormParametrosComponent, canActivate: [CheckNotloginGuard] },
      { path: 'parametros-editar/:id', component: FormParametrosComponent, canActivate: [CheckNotloginGuard] },
      { path: 'impuestos', component: ImpuestoComponent, canActivate: [CheckNotloginGuard] },
      { path: 'libroContable', component: LibroContableComponent, canActivate: [CheckNotloginGuard] },
      { path: 'bodegas', component: BodegasComponent, canActivate: [CheckNotloginGuard] },

    ]),
    BrowserAnimationsModule
  ],
  //aca se agregan todos los services
  providers: [ThemeService, UsuariosService, EmpleadosService, FacturasService, TercerosService, BirthdayAlertService,
    TipoMovimientosService, EmpleadosService, NominaService, LiquidacionService, TotalLiquidacionService, CuentaService,
    BodegasService, PromocionesService, PruebasSinVSService, InventarioService,AlertService,DatePipe,//{provide: THEME_CONFIG, useValue: COMMON_CONSTANTS.themeServiceConfig,  },
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } }],
  entryComponents: [SidebarComponent, TableDetallesComponent, DialogoCrearFacturaComponent, DialogoTipoTerceroComponent,
    DialogoMarcaComponent, DialogoCategoriaComponent, DialogoImpuestoComponent, DialogoBodegasComponent],
  bootstrap: [AppComponent, SidebarComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
