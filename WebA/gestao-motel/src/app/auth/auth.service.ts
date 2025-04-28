import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { TokenResponse } from './token.model';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private currentTokenSubject = new BehaviorSubject<string | null>(null);
  public currentToken$ = this.currentTokenSubject.asObservable();

  constructor(private http: HttpClient) {
    const token = localStorage.getItem('token');
    this.currentTokenSubject.next(token);
  }

  login(email: string, password: string): Observable<void> {
    return this.http.post<TokenResponse>(`${environment.apiUrl}/auth/sigin`, { email, password })
      .pipe(
        map(res => {
          localStorage.setItem('token', res.token);
          this.currentTokenSubject.next(res.token);
        })
      );
  }

  register(name: string, email: string, password: string): Observable<void> {
    return this.http.post<TokenResponse>(`${environment.apiUrl}/auth/newaccount`, { name, email, password })
      .pipe(
        map(res => {
          localStorage.setItem('token', res.token);
          this.currentTokenSubject.next(res.token);
        })
      );
  }

  logout(): void {
    localStorage.removeItem('token');
    this.currentTokenSubject.next(null);
  }

  getToken(): string | null {
    return this.currentTokenSubject.value;
  }
}