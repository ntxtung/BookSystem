import { Component, OnInit } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { User } from 'src/app/models/user.model';
import { Router } from '@angular/router';
import { UserAuthorizationService } from 'src/app/services/user-services/user-authorization.service';
import { Store, select } from "@ngrx/store"

@Component({
    selector: 'user-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    loginUserData = {
        username: null,
        password: null
    }
    loggedUser : User = new User()
    isLogged = false;
    error = false;
    nullUsername = false;
    nullPassword = false;

    constructor(
        private userAuthenticationService : UserAuthenticationService, 
        private userAuthorizationService: UserAuthorizationService,
        private store: Store<any>, 
        private router: Router
    ) { }

    ngOnInit() {
        this.store.pipe(select("users")).subscribe(
            users => {
                if(users){
                    if(users.isLogged === true){
                        this.router.navigate(['/books'])
                    }
                }
            }
        )
    }

    login(){
        this.nullUsername = (this.loginUserData.username === null)? true : false;
        this.nullPassword = (this.loginUserData.password === null)? true : false;

        if(!this.nullUsername && !this.nullPassword){
            this.userAuthenticationService.loginUserWithBody(this.loginUserData).subscribe(
                res => {
                    if(res.token){
                        this.isLogged = true;
                        this.loggedUser = res
                        this.stateStoring(this.loggedUser)
                        this.router.navigate(['/books'])
                    }
                },
                err => {
                    if(err.status === 401){
                        this.error = true;
                    }
                }
            )
        }else {
            console.log("username or password cannot be empty")
        }
        
    }

    stateStoring(user: User){
        this.store.dispatch({
            type: "LOGIN",
            payload: {
                user: user,
                isLogged: true
            }
        })
    }
}
