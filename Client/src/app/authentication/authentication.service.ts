import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private path = environment.identityServiceUrl + "identity/login";
    
    constructor(private http: HttpClient) { }

    login(data): Observable<any> {
        return this.http.post(this.path, data)
    }

    register(data): Observable<any> {
        return this.http.post(this.path, data)
    }

    saveToken(token) {
        localStorage.setItem('token', token)
    }

    saveTokenCompany(token) {
        localStorage.setItem('companyToken', token)
    }

    getCompanyToken() {
        return localStorage.getItem('companyToken')
    }

    getToken() {
        return localStorage.getItem('token')
    }

    isAuthenticated() {
        if (this.getToken()) {
            return true
        }
        return false;
    }
}