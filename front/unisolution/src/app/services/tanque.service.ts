import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TanqueService {
  // headers = new HttpHeaders({ 'Content-Type': 'application/json', });
  private apiUrl = '/api/Tanque';
  constructor(protected http: HttpClient) {
  }

  get(): any {
    return this.http.get(this.apiUrl);
  }

  getByDeposito(deposito: any) {
    return this.http.get(this.apiUrl + '/bydeposito/' + deposito);
  }

  novo(data: any): Observable<any> {
    return this.http.post(this.apiUrl, data);
  }
  update(data: any): Observable<any> {
    return this.http.put(this.apiUrl, data);
  }

  delete(deposito: string): Observable<any> {
    return this.http.delete(this.apiUrl + '/' + deposito);
  }
}
