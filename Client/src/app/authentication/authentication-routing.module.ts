import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { RegisterCompanyComponent } from './register-company/register-company.component'
import { LoginCompanyComponent } from './login-company/login-company.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'login-company', component: LoginCompanyComponent },
  { path: 'register-user', component: RegisterUserComponent },
  { path: 'register-company', component: RegisterCompanyComponent },
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule { }