import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-crud',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './crud.html',
  styleUrls: ['./crud.scss']
})
export class Crud {
  // Lista vacía al iniciar
  items: { id: number; title: string }[] = [];

  nuevo = { title: '' };
  nextId = 1;

  agregar() {
    if (!this.nuevo.title.trim()) return;
    this.items.push({ id: this.nextId++, title: this.nuevo.title });
    this.nuevo.title = '';
  }

  eliminar(id: number) {
    const item = this.items.find(i => i.id === id);
    if (!item) return;

    const confirmado = window.confirm(`¿Está seguro que desea eliminar "${item.title}"?`);
    if (confirmado) {
      this.items = this.items.filter(i => i.id !== id);
    }
  }
}
