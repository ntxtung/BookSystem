import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserAuthorizationService {

    token: string;
    isLogged: boolean;

    constructor() {
        this.checkAuthorization();
    }

    // The return type of an async function or method must be the global Promise<T> type
    checkAuthorization(): boolean {
        this.token = localStorage.getItem("token");
        this.isLogged = (this.token != null) ? true : false;
        return this.isLogged;
    }

    getToken() :string {
        return localStorage.getItem("token")
    }

    setHeader(): HttpHeaders{
        return new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': "Bearer " + this.token
        })
    }
}
