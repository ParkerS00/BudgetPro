import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService, User } from '../services/auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  email: string = '';
  emailError: string = '';
  emailSuccess: boolean = false;

  constructor(private authService: AuthService) {}

  onSubmit() {
    this.authService.getUserByEmail(this.email).subscribe({
      next: (user) => {
        this.emailSuccess = true;
        this.emailError = '';
        this.authService.setUser(user);
      },
      error: (err) => {
        console.error('Failed to fetch user:', err);
      },
    });
  }
}
