import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { LoginComponent } from './login/login.component';
import { RegisterUserComponent } from './register-user/register-user.component';
import { RegisterCompanyComponent } from './register-company/register-company.component';
import { LoginCompanyComponent } from './login-company/login-company.component';


@NgModule({
  declarations: [
    LoginComponent,
    LoginCompanyComponent,
    RegisterUserComponent,
    RegisterCompanyComponent,
    LoginCompanyComponent,
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  exports:[
    LoginComponent,
    LoginCompanyComponent,
    RegisterUserComponent,
    RegisterCompanyComponent,
  ]
})
export class AuthenticationModule { }
