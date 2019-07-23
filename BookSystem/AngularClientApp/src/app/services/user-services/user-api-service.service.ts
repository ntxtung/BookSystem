import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserApiService {
    private BASE_URL = "http://localhost:5000"
    users : any
    constructor(private httpClient : HttpClient) { }

    getUsers(){
        return this.httpClient.get(`${this.BASE_URL}/api/users`)
    }
}
