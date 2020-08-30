import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthenticationService, private router: Router) {
    this.loginForm = this.fb.group({
      'email': ['', Validators.required],
      'password': ['', Validators.required]
    })
  }

  ngOnInit() {
  }

  login() {
    this.authService.saveToken('test-token');
    this.router.navigate(["pets/user-landing"]).then(() => location.reload());
    // this.authService.login(this.loginForm.value).subscribe(data => {
    //   this.authService.saveToken(data['token']);
    //   this.router.navigate([""]).then(() => location.reload());
    // })
  }

  get getEmail() {
    return this.loginForm.get('email')
  }

  get password() {
    return this.loginForm.get('password')
  }
}