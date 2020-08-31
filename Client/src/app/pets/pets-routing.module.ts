import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyLandingComponent } from './company-landing/company-landing.component';
import { UserLandingComponent } from './user-landing/user-landing.component';
import { PatientsComponent } from './patients/patients.component';
import { PatientInfoComponent } from './patient-info/patient-info.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';

const routes: Routes = [
  { path: 'company-landing', component: CompanyLandingComponent },
  { path: 'user-landing', component: UserLandingComponent },
  { path: 'all', component: PatientsComponent },
  { path: 'patient-info/:id', component: PatientInfoComponent },
  { path: 'add-medical-record/:id', component: MedicalRecordComponent },

];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class PetsRoutingModule { }