import { Component } from '@angular/core';
import {
  AddCategoryRequest,
  Category,
  CategoryService,
  FindCategoryRequest,
} from '../services/category/category.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { User, AuthService } from '../services/auth/auth.service';
import { RouterModule } from '@angular/router';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { YesNoButtonsComponent } from '../shared/yes-no-buttons/yes-no-buttons.component';
import { NotLoggedInComponent } from '../shared/not-logged-in/not-logged-in.component';

@Component({
  selector: 'app-transaction',
  standalone: true,
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css'],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatSnackBarModule,
    YesNoButtonsComponent,
    NotLoggedInComponent
],
})
export class TransactionComponent {
  categories: Category[] = [];
  user: User | null = null;
  newCategory: AddCategoryRequest = {
    name: '',
    isIncome: false,
    userId: this.user?.id || 0,
  };
  selectedCategory: number | null = null;
  needCategory: boolean = false;
  buttonClicked: boolean = false;
  categoryRequest: FindCategoryRequest = {
    id: this.selectedCategory || 0,
    name: this.newCategory.name || '',
    userId: this.user?.id || 0,
  };

  constructor(
    private categoryService: CategoryService,
    private authService: AuthService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.categoryService.getAllCategories().subscribe({
      next: (data: Category[]) => {
        this.categories = data;
      },
      error: (err) => {
        console.error('Error fetching categories:', err);
      },
    });

    this.user = this.authService.getUser();
    this.newCategory.userId = this.user?.id || 0;
  }

  setCategoryChoice(need: boolean) {
    this.needCategory = need;
    this.buttonClicked = true;
  }

  onSubmit() {
    this.categoryService.addNewCategory(this.newCategory).subscribe({
      next: (data: Category) => {
        console.log('Category added:', data);
        this.categories.push(data);
        this.newCategory = {
          name: '',
          isIncome: false,
          userId: this.user?.id || 0,
        };
        this.buttonClicked = false;
        this.snackBar.open('Category added successfully!', 'Close', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center',
          panelClass: ['custom-snackbar', 'custom-button'],
        });
      },
      error: (err) => {
        console.error('Error adding category:', err);
        this.snackBar.open('Error adding category', 'Close', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center',
          panelClass: ['custom-snackbar', 'custom-button'],
        });
      },
    });
  }
}
