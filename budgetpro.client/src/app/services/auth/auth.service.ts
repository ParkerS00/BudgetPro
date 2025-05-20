import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';

export interface RegisterUserRequest {
  email: string;
}

export interface FindUserRequest {
  email: string;
  id: number;
}

export interface User {
  id: number;
  email: string;
  createdAt: Date;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = environment.apiUrl;
  private userSubject = new BehaviorSubject<User | null>(null);
  user$ = this.userSubject.asObservable();

  constructor(private httpClient: HttpClient) {}

  getUser(): User | null {
    return this.userSubject.value;
  }

  setUser(user: User | null) {
    this.userSubject.next(user);
  }

  registerUser(email: string) {
    const requestBody = { email };
    return this.httpClient.post(`${this.apiUrl}/User/AddUser`, requestBody);
  }

  getUserByEmail(email: string): Observable<User> {
    const requestBody = { email, id: 0 };
    return this.httpClient
      .post<User>(`${this.apiUrl}/User/GetByEmail`, requestBody)
      .pipe(tap((user) => this.setUser(user)));
  }

  logUserOut() {
    this.setUser(null);
  }
}
