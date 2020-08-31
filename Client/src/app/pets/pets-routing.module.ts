import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyLandingComponent } from './company-landing/company-landing.component';
import { UserLandingComponent } from './user-landing/user-landing.component';
import { PatientsComponent } from './patients/patients.component';

const routes: Routes = [
  { path: 'company-landing', component: CompanyLandingComponent },
  { path: 'user-landing', component: UserLandingComponent },
  { path: 'all', component: PatientsComponent },

];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class PetsRoutingModule { }