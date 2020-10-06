import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';

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
    EmpleadosComponent,
    SidebarComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatListModule,
    BrowserAnimationsModule,
    //ACA SE REGISTRAN TODOS LOS COMPONENTES
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'usuarios', component: UsuariosComponent },
      { path: 'usuarios-crear', component: UsuariosFormComponent },


    ]),
    BrowserAnimationsModule
  ],
  //aca se agregan todos los services
  providers: [UsuariosService, EmpleadosService, { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' } }],
  entryComponents: [SidebarComponent],
  bootstrap: [AppComponent, SidebarComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
