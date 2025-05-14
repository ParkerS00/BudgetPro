import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';

export interface Category {
  id: number;
  name: string;
  isIncome: boolean;
  userId: number;
}

export interface FindCategoryRequest {
  id: number;
  name: string;
  userId: number;
}

export interface AddCategoryRequest {
  name: string;
  isIncome: boolean;
  userId: number;
}

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private readonly apiUrl = environment.apiUrl;

  constructor(private httpClient: HttpClient) {}

  getAllCategories() {
    return this.httpClient.get<Category[]>(`${this.apiUrl}/Category/GetAll`);
  }

  getCategoryById(request: FindCategoryRequest) {
    return this.httpClient.post<Category>(
      `${this.apiUrl}/Category/GetById}`,
      request
    );
  }

  addNewCategory(request: AddCategoryRequest) {
    return this.httpClient.post<Category>(
      `${this.apiUrl}/Category/Add`,
      request
    );
  }
}
