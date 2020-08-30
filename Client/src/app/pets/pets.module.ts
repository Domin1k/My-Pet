import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PetsRoutingModule } from './pets-routing.module';
import { CompanyLandingComponent } from './company-landing/company-landing.component';
import { UserLandingComponent } from './user-landing/user-landing.component';

@NgModule({
  declarations: [CompanyLandingComponent, UserLandingComponent],
  imports: [
    CommonModule,
    PetsRoutingModule
  ]
})
export class PetsModule { }
