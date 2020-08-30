import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-company',
  templateUrl: './login-company.component.html',
  styleUrls: ['./login-company.component.css']
})
export class LoginCompanyComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthenticationService, private router: Router) {
    this.loginForm = this.fb.group({
      'vet-id': ['', Validators.required],
      'password': ['', Validators.required]
    })
  }

  ngOnInit() {
  }

  login() {
    this.authService.saveTokenCompany('token-value');
    this.router.navigate(["pets/company-landing"]).then(() => location.reload());
    // this.authService.login(this.loginForm.value).subscribe(data => {
    //   this.authService.saveToken(data['token']);
    //   this.router.navigate([""]).then(() => location.reload());
    // })
  }

  get getVetId() {
    return this.loginForm.get('vet-id')
  }

  get password() {
    return this.loginForm.get('password')
  }
}
