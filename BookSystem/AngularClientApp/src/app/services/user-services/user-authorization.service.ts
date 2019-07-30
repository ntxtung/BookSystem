import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { Store, select } from "@ngrx/store"
import { UserState } from 'src/app/user/user-state/user.reducer';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class UserAuthorizationService {

    currentUserState: any
    token: string;
    isLogged: boolean;

    constructor(private store: Store<any>, private router: Router) {
        this.store.pipe(select("users")).subscribe(
            users => {
                if(users){
                    this.token = users.token
                }
            }
        )
        // this.currentUserState = this.checkAuthorization()
        // this.token = this.currentUserState.token
    }

    checkAuthorization(){
        this.store.pipe(select("users")).subscribe(
            users => {
                if(users){
                    if(users.isLogged === false){
                        this.router.navigate(['/login'])
                    }
                }
            }
        )
    }

    setHeader(): HttpHeaders{
        return new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': "Bearer " + this.token
        })
    }
}
