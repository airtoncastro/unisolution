import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TipoProdutoService {
  private apiUrl = '/api/TipoProduto';
  constructor(protected http: HttpClient) {
  }

  get() {
    return this.http.get<any>(this.apiUrl);
  }

  getById(id: any) {
    return this.http.get(this.apiUrl + '/' + id);
  }

  novo(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
  update(data: any): Observable<any> {
    return this.http.put(this.apiUrl, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(this.apiUrl + '/' + id);
  }
}
