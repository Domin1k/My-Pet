import { Component, OnInit } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-medical-record',
  templateUrl: './medical-record.component.html',
  styleUrls: ['./medical-record.component.css']
})
export class MedicalRecordComponent implements OnInit {
  medicalForm: FormGroup;
  model: NgbDateStruct;

  constructor(private fb: FormBuilder) {
    this.medicalForm = this.fb.group({
      ngbDatepicker: [''],
      medicalRecord: [''],
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    console.warn(this.medicalForm.value)
  }
}
