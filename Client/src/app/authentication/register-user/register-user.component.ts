import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {
  registerForm: FormGroup;
  
  constructor(private fb: FormBuilder,  private router: Router, private authService: AuthenticationService) {
    this.registerForm = this.fb.group({
      'username': ['', Validators.required],
      'email': ['', Validators.required],
      'password': ['', Validators.required]
    })
   }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.router.navigate(["auth/login"]);
    })
  }

  get username() {
    return this.registerForm.get('username')
  }

  get email() {
    return this.registerForm.get('email')
  }

  get password() {
    return this.registerForm.get('password')
  }
}
