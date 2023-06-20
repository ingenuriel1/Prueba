import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { AppComponent } from '../app.component';

@Injectable({
  providedIn: 'root'
})
export class ReporteService {
  private urlApi: string;
  constructor(private http: HttpClient) {
    let x=new AppComponent();
    this.urlApi ='https://localhost:7280';
  }
  
  getRecaudos(): Observable<any> {
    return this.http.get(this.urlApi+'/api/Recaudos');
  } 
  getTotales(): Observable<any> {
    return this.http.get(this.urlApi+'/api/Recaudos/GetTotales');
  }  
  getFechas(): Observable<any> {
    return this.http.get(this.urlApi+'/api/Recaudos/GetFechas');
  } 
  getEstaciones(): Observable<any> {
    return this.http.get(this.urlApi+'/api/Recaudos/GetEstaciones');
  } 

}
