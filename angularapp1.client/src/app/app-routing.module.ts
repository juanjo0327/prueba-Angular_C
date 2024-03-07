import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgregarComponent } from './modules/Agregar/agregar.component';
import { InicioComponent } from './modules/Inicio/Inicio.component';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { ModificarComponent } from './modules/Modificar/modificar.component';
import { ModificarProducto } from './modules/Modificar/modificarProducto/modificarProducto.component';

const routes: Routes =
  [
    { path: 'inicio', component: InicioComponent },
    { path: 'agregar', component: AgregarComponent },
    { path: 'modificar', component: ModificarComponent },
    { path: 'modificarProducto/:id', component: ModificarProducto },
    { path: '', redirectTo: '/inicio', pathMatch: 'full' },
  ];

@NgModule({
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    CommonModule,
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule, BrowserModule],
})
export class AppRoutingModule { }
