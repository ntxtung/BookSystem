import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { Store, select } from "@ngrx/store"

@Injectable({
    providedIn: 'root'
})
export class UserAuthorizationService {

    token: string;
    isLogged: boolean;

    constructor(private store: Store<any>) {
        // this.checkAuthorization();
        this.store.pipe(select("users")).subscribe(
            users => {
                console.log("users-state: " + JSON.stringify(users))
                if(users){
                    this.token = users.user.token
                    console.log(this.token)
                }
            }
        )
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
        console.log("token: "+this.token)
        return new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': "Bearer " + this.token
        })
    }
}
