import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { User } from '../../services/auth/auth.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-not-logged-in',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './not-logged-in.component.html',
  styleUrl: './not-logged-in.component.css',
})
export class NotLoggedInComponent {
  @Input() user: User | null = null;
  @Input() heading: string = '';
}
