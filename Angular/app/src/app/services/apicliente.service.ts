import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response';
import { Cliente } from "../models/cliente";

const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json' // Sirve para cuando hagamos solicitudes post le mandamos el encabezado
  })
}

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {

  url: string = 'https://localhost:44312/api/Client'
  constructor(
    private _http: HttpClient
  ) { }

//Siempre que hagamos una solicitud a un servicio se usa Observable
getClientes(): Observable<Response>{
  return this._http.get<Response>(this.url);
}


  add(cliente: Cliente): Observable<Response>{
    return this._http.post<Response>(this.url, cliente, httpOption);
  }

  edit(cliente: Cliente): Observable<Response>{
    return this._http.put<Response>(this.url, cliente, httpOption);
  }

  delete(cliId: number): Observable<Response>{
    return this._http.delete<Response>(`${this.url}?cliId=${cliId}`);
  }
}