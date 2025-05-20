import { Injectable } from '@angular/core';
import { Category } from '../category/category.service';
import { User } from '../auth/auth.service';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

export interface Budget {
  id: number;
  userId: number;
  categoryId: number;
  amount: number;
  endDate: Date;
  startDate: Date;
  name: string;
  category: Category;
  user: User;
}

export interface AddBudgetRequest {
  userId: number;
  categoryId: number;
  amount: number;
  endDate: Date;
  startDate: Date;
  name: string;
}

export interface FindBudgetRequest {
  id: number;
  userId: number;
  categoryId: number;
  endDate: Date;
  startDate: Date;
  name: string;
}

@Injectable({
  providedIn: 'root',
})
export class BudgetService {
  private apiUrl = environment.apiUrl + '/Budget';

  constructor(private httpClient: HttpClient) {}

  getAllBudgets() {
    return this.httpClient.get<Budget[]>(`${this.apiUrl}/GetAll`);
  }

  addNewBudget(request: AddBudgetRequest) {
    return this.httpClient.post<Budget>(`${this.apiUrl}/Add`, request);
  }

  getBudgetById(request: FindBudgetRequest) {
    return this.httpClient.post<Budget>(`${this.apiUrl}/GetById`, request);
  }

  getBudgetsByUser(request: FindBudgetRequest) {
    return this.httpClient.post<Budget[]>(`${this.apiUrl}/GetByUser`, request);
  }

  getBudgetsByCategory(request: FindBudgetRequest) {
    return this.httpClient.post<Budget[]>(
      `${this.apiUrl}/GetByCategory`,
      request
    );
  }

  getBudgetByTimeFrame(request: FindBudgetRequest) {
    return this.httpClient.post<Budget>(
      `${this.apiUrl}/GetByTimeFrame`,
      request
    );
  }

  getBudgetByName(request: FindBudgetRequest) {
    return this.httpClient.post<Budget>(`${this.apiUrl}/GetByName`, request);
  }
}
