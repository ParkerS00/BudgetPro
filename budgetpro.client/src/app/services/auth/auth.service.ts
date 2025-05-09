import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

export interface RegisterUserRequest {
  email: string;
}

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) {}

  registerUser(email: string) {
    const requestBody: RegisterUserRequest = { email };
    return this.httpClient.post(`${this.apiUrl}/User/AddUser`, requestBody);
  }
}
