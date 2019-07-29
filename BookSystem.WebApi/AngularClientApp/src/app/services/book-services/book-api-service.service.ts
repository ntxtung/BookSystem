import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserAuthorizationService } from '../user-services/user-authorization.service';

@Injectable({
    providedIn: 'root'
})
export class BookApiService {
    private BASE_URL = "http://localhost:5000"
    constructor(private httpClient: HttpClient, private userAuthorizationService: UserAuthorizationService) { }

    getBooks(){
        return this.httpClient.get(`${this.BASE_URL}/api/books`, { headers: this.userAuthorizationService.setHeader()});
    }
}
