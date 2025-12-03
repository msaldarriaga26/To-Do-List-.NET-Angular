import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrls: ['./login.scss']
})
export class LoginComponent {
  usuario = { email: '', password: '' };

  login() {
    console.log('Email:', this.usuario.email);
    console.log('Contraseña:', this.usuario.password);
    alert(`Iniciando sesión con: ${this.usuario.email}`);
    // Aquí podrías agregar lógica real de autenticación
  }
}
