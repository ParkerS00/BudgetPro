import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {
  provideHttpClient,
  withInterceptorsFromDi,
} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RegisterComponent } from './register/register.component';
import { BudgetComponent } from './budget/budget.component';
import { TransactionComponent } from './transaction/transaction.component';
import { GoalComponent } from './goal/goal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [AppComponent, GoalComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NavbarComponent,
    RegisterComponent,
    TransactionComponent,
    BrowserAnimationsModule,
    BudgetComponent,
  ],
  providers: [provideHttpClient(withInterceptorsFromDi())],
  bootstrap: [AppComponent],
})
export class AppModule {}
