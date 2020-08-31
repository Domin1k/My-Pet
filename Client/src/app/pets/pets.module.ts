import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PetsRoutingModule } from './pets-routing.module';
import { CompanyLandingComponent } from './company-landing/company-landing.component';
import { UserLandingComponent } from './user-landing/user-landing.component';
import { PatientsComponent } from './patients/patients.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PatientInfoComponent } from './patient-info/patient-info.component';
import { MedicalRecordComponent } from './medical-record/medical-record.component';

@NgModule({
  declarations: [CompanyLandingComponent, UserLandingComponent, PatientsComponent, PatientInfoComponent, MedicalRecordComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PetsRoutingModule,
    FormsModule,
    NgbModule
  ]
})
export class PetsModule { }
