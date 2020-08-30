import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  token: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.getToken();
    // this.notificationsService.subscribe();
  }

  getToken() {
    this.token = localStorage.getItem('token')
  }
  
  route(param) {
    this.router.navigate([param])
  }
}
