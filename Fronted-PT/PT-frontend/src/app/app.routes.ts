import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login';
import { TaskList } from './tasks/task-list/task-list';
import { Dashboard } from './tasks/dashboard/dashboard';

export const routes: Routes = [
  { path: 'auth', component: LoginComponent },
  { path: 'tasks', component: TaskList },
  { path: 'dashboard', component: Dashboard },
  { path: '', redirectTo: 'auth', pathMatch: 'full' },
  { path: '**', redirectTo: 'auth' }
];
