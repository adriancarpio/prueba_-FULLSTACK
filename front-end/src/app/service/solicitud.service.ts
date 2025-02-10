import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class SolicitudService {

  constructor(
    private http: HttpClient
  ) { }

  private apiUrlForms = 'http://localhost:5250/api/Form';
  private apiUrlInput = 'http://localhost:5250/api/Input';
  getForms(): Observable<any> {
    return this.http.get<any>(`${this.apiUrlForms}`);
  }

  getForm(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrlForms}/${id}`);
  }

  createForm(form: any): Observable<any> {
    return this.http.post<any>(this.apiUrlForms, form);
  }

  updateForm(form: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrlForms}/${form.id}`, form);
  }

  deleteForm(id: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrlForms}/${id}`);
  }

  getInputs(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrlInput}`);
  }

  getInput(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrlInput}/${id}`);
  }

  createInput(input: any): Observable<any> {
    return this.http.post<any>(this.apiUrlInput, input);
  }

  deleteInput(id: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrlInput}/${id}`);
  }

}
