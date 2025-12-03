import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class CrudService {
  private api = 'https://localhost:5001/api/todo';

  constructor(private http: HttpClient) {}

  obtener() { return this.http.get<any[]>(this.api); }
  crear(data: any) { return this.http.post(this.api, data); }
  eliminar(id: number) { return this.http.delete(`${this.api}/${id}`); }
}
