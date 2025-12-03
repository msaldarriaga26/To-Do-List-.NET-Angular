// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { Inicio } from './paginas/inicio/inicio';
import { LoginComponent } from './paginas/login/login';
import { Crud } from './paginas/crud/crud';

export const routes: Routes = [
  { path: '', component: Inicio },
  { path: 'login', component: LoginComponent },
  { path: 'crud', component: Crud },
  { path: '**', redirectTo: '' }
];
