import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { BudgetComponent } from './budget/budget.component';
import { TransactionComponent } from './transaction/transaction.component';
import { GoalComponent } from './goal/goal.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent, title: 'Register Page' },
  { path: 'login', component: LoginComponent, title: 'Login Page' },
  { path: '', component: HomeComponent, title: 'Home Page' },
  { path: 'budget', component: BudgetComponent, title: 'Budget Page' },
  {
    path: 'transaction',
    component: TransactionComponent,
    title: 'Transaction Page',
  },
  { path: 'goal', component: GoalComponent, title: 'Goal Page' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
