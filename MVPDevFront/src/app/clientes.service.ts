import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from './Models/Cliente';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'})
};

const requestOptions: Object = {
  responseType: 'text'
};

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  url = 'https://localhost:7118/api/cliente';

  constructor(private http: HttpClient) { }

  ListarClientes(): Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.url)
  }

  BuscarCliente(clienteId: number): Observable<Cliente>{
    const apiUrl = `${this.url}/${clienteId}`;
    return this.http.get<Cliente>(apiUrl);
  }

  AdicionarCliente(cliente: Cliente) : Observable<any>{
    return this.http.post<Cliente>(this.url, cliente, requestOptions);
  }

  AtualizarCliente(clienteId: number, cliente: Cliente) : Observable<any>{
    const apiUrl = `${this.url}/${clienteId}`;
    return this.http.put<Cliente>(apiUrl, cliente, requestOptions);
  }

  ExcluirCliente(clienteId: number) : Observable<any>{
    const apiUrl = `${this.url}/${clienteId}`;
    return this.http.delete<Cliente>(apiUrl, requestOptions);
  }
}
