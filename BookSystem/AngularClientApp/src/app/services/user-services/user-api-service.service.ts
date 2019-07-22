import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserApiService {
    users : any
    constructor(private httpClient : HttpClient) { }

    getUsers(){
        return this.httpClient.get("http://localhost:5000/api/users")
    }
}
