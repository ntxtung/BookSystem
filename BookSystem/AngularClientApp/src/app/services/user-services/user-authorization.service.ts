import { Injectable } from '@angular/core';

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
}
