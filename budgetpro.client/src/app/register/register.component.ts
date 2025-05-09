import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../services/auth/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  email: string = '';
  emailError: string = '';
  emailSuccess: boolean = false;

  constructor(private authService: AuthService) {}

  onSubmit() {
    this.authService.registerUser(this.email).subscribe({
      next: () => {
        this.email = '';
        this.emailError = '';
        this.emailSuccess = true;
      },
      error: () => {
        this.emailError = 'Email already exists';
        this.emailSuccess = false;
      },
    });
  }
}
