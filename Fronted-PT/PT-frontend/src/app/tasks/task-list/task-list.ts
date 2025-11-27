import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.html',
  styleUrls: ['./task-list.scss'],
  standalone: true,
  imports: [CommonModule]
})
export class TaskList {
  userName: string = 'Usuario';
}
