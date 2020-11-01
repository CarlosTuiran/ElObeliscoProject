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
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { UsuariosService } from './usuarios/usuarios.service';
import { UsuariosFormComponent } from './usuarios/usuarios-form/usuarios-form.component';
import { EmpleadosComponent } from './empleados/empleados.component';
import { EmpleadosService } from './empleados/empleados.service';
import { SidebarComponent } from './sidebar/sidebar.component';

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import {ConfirmEqualValidatorDirective} from './usuarios/usuarios-form/confirm-equal-validator.directive';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { DemoMaterialModule } from './material-module';
import { ProductosComponent } from './productos/productos.component';
import { EmpleadosFormComponent } from './empleados/empleados-form/empleados-form.component';
import { ProductosFormComponent } from './productos/productos-form/productos-form.component';
import { TercerosComponent } from './terceros/terceros.component';
import { TercerosFormComponent } from './terceros/terceros-form/terceros-form.component'; 
import { TercerosService } from './terceros/terceros.service';
import { NominaComponent } from './nomina/nomina.component';
import { NominaService } from './nomina/nomina.service';
import { NominaFormComponent } from './nomina/nomina-form/nomina-form.component';
import { TotalLiquidacionComponent } from './total-liquidacion/total-liquidacion.component';
import { TotalLiquidacionService } from './total-liquidacion/total-liquidacion.service';
import { LiquidacionComponent } from './liquidacion/liquidacion.component';
import { LiquidacionService } from './liquidacion/liquidacion.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
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
    NominaComponent,
    NominaFormComponent,
    TotalLiquidacionComponent,
    LiquidacionComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    CommonModule,
    DataTablesModule,
    //ACA SE REGISTRAN TODOS LOS COMPONENTES
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'usuarios', component: UsuariosComponent },
      { path: 'usuarios-crear', component: UsuariosFormComponent },
      { path: 'usuarios-editar/:id', component: UsuariosFormComponent },
      { path: 'productos', component: ProductosComponent },
      { path: 'productos-crear', component: ProductosFormComponent },
      { path: 'productos-editar/:id', component: ProductosFormComponent },
      { path: 'terceros', component: TercerosComponent },
      { path: 'terceros-crear', component: TercerosFormComponent },
      { path: 'terceros-editar/:id', component: TercerosFormComponent },
      { path: 'empleados', component: EmpleadosComponent },
      { path: 'empleados-crear', component: EmpleadosFormComponent },
      { path: 'empleados-editar/:id', component: EmpleadosFormComponent },
      { path: 'nominas', component: NominaComponent },
      { path: 'nominas-crear', component: NominaFormComponent },
      { path: 'nominas-editar/:id', component: NominaFormComponent },
      { path: 'liquidaciones', component: LiquidacionComponent },
      { path: 'total-liquidaciones', component: TotalLiquidacionComponent }

    ]),
    BrowserAnimationsModule
  ],
  //aca se agregan todos los services
  providers: [UsuariosService, EmpleadosService, TercerosService, EmpleadosService, NominaService, LiquidacionService, TotalLiquidacionService,{ provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } }],
  entryComponents: [SidebarComponent],
  bootstrap: [AppComponent, SidebarComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
