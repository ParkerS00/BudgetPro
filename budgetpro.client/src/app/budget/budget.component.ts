import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService, User } from '../services/auth/auth.service';
import { NotLoggedInComponent } from '../shared/not-logged-in/not-logged-in.component';
import { YesNoButtonsComponent } from '../shared/yes-no-buttons/yes-no-buttons.component';
import {
  AddBudgetRequest,
  BudgetService,
} from '../services/budget/budget.service';
import {
  Category,
  CategoryService,
} from '../services/category/category.service';
import { FormsModule } from '@angular/forms';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-budget',
  standalone: true,
  imports: [
    CommonModule,
    NotLoggedInComponent,
    YesNoButtonsComponent,
    FormsModule,
    MatSnackBarModule,
  ],
  templateUrl: './budget.component.html',
  styleUrl: './budget.component.css',
})
export class BudgetComponent {
  user: User | null = null;
  buttonClicked: boolean = false;
  needBudget: boolean = false;
  budgetAmount: number = 0;
  budgetCategoryId: number = 0;
  budgetName: string = '';
  budgetStartDate: Date = new Date();
  budgetEndDate: Date = new Date();
  categories: Category[] = [];

  addBudgetRequest: AddBudgetRequest = {
    userId: this.user?.id || 0,
    categoryId: 0,
    amount: this.budgetAmount,
    endDate: this.budgetEndDate,
    startDate: this.budgetStartDate,
    name: this.budgetName,
  };

  constructor(
    private authService: AuthService,
    private categoryService: CategoryService,
    private budgetService: BudgetService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit() {
    this.user = this.authService.getUser();
    this.categoryService.getAllCategories().subscribe({
      next: (data: Category[]) => {
        this.categories = data;
      },
      error: (err) => {
        console.error('Error fetching categories:', err);
      },
    });
  }

  setBudgetChoice(choice: boolean) {
    this.needBudget = choice;
    this.buttonClicked = true;
  }

  onSubmit() {
    this.addBudgetRequest = {
      userId: this.user?.id || 0,
      categoryId: Number(this.budgetCategoryId),
      amount: Number(this.budgetAmount),
      startDate: this.budgetStartDate,
      endDate: this.budgetEndDate,
      name: this.budgetName,
    };

    console.log(this.addBudgetRequest);
    this.budgetService.addNewBudget(this.addBudgetRequest).subscribe({
      next: (response) => {
        console.log('Budget added:', response);
        this.snackBar.open('Budget added successfully!', 'Close', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center',
          panelClass: ['custom-snackbar', 'custom-button'],
        });
      },
      error: (err) => {
        console.error('Error:', err);
        this.snackBar.open('Error adding budget', 'Close', {
          duration: 2000,
          verticalPosition: 'top',
          horizontalPosition: 'center',
          panelClass: ['custom-snackbar', 'custom-button'],
        });
      },
    });
  }
}
