import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppComponent } from '../app.component';

import { Usuario } from '../inicio/usuario';
@Injectable({
  providedIn: 'root'
})
export class InicioService {
  private urlApi: string;
  constructor(private http: HttpClient) {
    let x=new AppComponent();
    this.urlApi ='https://localhost:7280';
  }
  
  getRecaudos(): Observable<any> {
    return this.http.get(this.urlApi+'/api/Recaudos');
  } 
  PostRecaudoSeguridad():Observable<any> {
    let usuario={
      "id": 1,
      "login": "carlos",
      "clave": "1234"
    };
    return this.http.post(this.urlApi+'/api/Recaudos/PostRecaudoSeguridad', usuario);
  }
}
