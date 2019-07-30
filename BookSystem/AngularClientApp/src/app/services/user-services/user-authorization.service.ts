import { Injectable } from '@angular/core';
import { HttpHeaders } from '@angular/common/http';
import { Store, select } from "@ngrx/store"
import { UserState } from 'src/app/user/user-state/user.reducer';

@Injectable({
    providedIn: 'root'
})
export class UserAuthorizationService {

    currentUserState: any
    token: string;
    isLogged: boolean;

    constructor(private store: Store<any>) {
        this.checkAuthorization();
        this.store.pipe(select("users")).subscribe(
            users => {
                console.log("users-state: " + JSON.stringify(users))
                if(users){
                    this.token = users.token
                    console.log(this.token)
                }
            }
        )
        // this.currentUserState = this.checkAuthorization()
        // this.token = this.currentUserState.token
    }

    checkAuthorization(): any{
        this.store.pipe(select("users")).subscribe(
            users => {
                if(users){
                    return users
                }
            }
        )
    }

    setHeader(): HttpHeaders{
        console.log("token: "+this.token)
        return new HttpHeaders({
            'Content-Type': 'application/json',
            'Authorization': "Bearer " + this.token
        })
    }
}
