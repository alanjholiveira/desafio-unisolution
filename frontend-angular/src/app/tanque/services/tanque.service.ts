import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { environment } from 'src/environments/environment';
import { Tanque } from "../model/tanque.model";


@Injectable({
  providedIn: 'root'
})
export class TanqueService {

  private readonly API = `${environment.API}tanque`;
  public tanques: Tanque[];

  constructor(
    private http: HttpClient
  ) { }

  /** Listar */
  public listar(): Observable<Tanque[]> {
    return this.http.get<Tanque[]>(this.API)
                    .pipe(
                      catchError(this.handleError)
                    );
  }

  /** Deletar */
  public deletar(id: number) {
    return this.http.delete(this.API + '/' + id)
                    .pipe(
                      catchError(this.handleError)
                    );
  }

  /** Obter */
  public obterTanque(id: number): Observable<Tanque> {
    return this.http.get<Tanque>(this.API + '/' + id)
                    .pipe(
                      catchError(this.handleError)
                    );
  }

  /** Criar */
  public store(tanque: Tanque): Observable<Tanque> {
    return this.http.post<Tanque>(this.API, tanque)
                    .pipe(
                      catchError(this.handleError)
                    );
  }

  /** Atualizar */
  public update(tanque: Tanque): Observable<Tanque> {
    return this.http.put<Tanque>(this.API, tanque)
                    .pipe(
                      catchError(this.handleError)
                    );
  }


  /** Handle Error */
  private handleError(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Codigo do erro: ${error.status},
                          messagem: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }

}
