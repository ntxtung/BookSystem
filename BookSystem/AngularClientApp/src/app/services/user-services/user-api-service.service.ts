import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserApiService {

    constructor(private httpClient : HttpClient) { }

    getAllUsers(){
        return this.httpClient.get("206.189.40.187:5000/api/users")
    }

    getUserById(id : number){

    }

    createUser(user : any){

    }
}
