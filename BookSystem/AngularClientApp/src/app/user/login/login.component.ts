import { Component, OnInit } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { User } from 'src/app/models/user';
import { Router } from '@angular/router';
import { UserAuthorizationService } from 'src/app/services/user-services/user-authorization.service';

declare let toastr

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
        private router: Router
    ) { }

    ngOnInit() {
    }

    login(){
        this.nullUsername = (this.loginUserData.username === null)? true : false;
        this.nullPassword = (this.loginUserData.password === null)? true : false;

        if(!this.nullUsername && !this.nullPassword){
            console.log(this.nullUsername+" - "+ this.nullPassword)
            this.userAuthenticationService.loginUserWithBody(this.loginUserData).subscribe(
                res => {
                    if(res.token){
                        this.isLogged = true;
                        this.loggedUser.id = res.id
                        this.loggedUser.token = res.token
                        localStorage.setItem('token', res.token)

                        // value that is gonna saved in localStorage must be a string
                        localStorage.setItem('user', JSON.stringify(res))
                        this.userAuthorizationService.checkAuthorization()
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
}
