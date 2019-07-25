import { Component, OnInit } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { User } from 'src/app/models/user';
import { Router } from '@angular/router';

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
    test = "blahhhhh";
    
    constructor(private userAuthenticationService : UserAuthenticationService, private router: Router) { }

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
                        toastr.success("login success as "+res.firstname+" "+res.lastname)
                        this.isLogged = true;
                        this.loggedUser.id = res.id
                        this.loggedUser.token = res.token
                        console.log(this.loggedUser)
                        localStorage.setItem('token', res.token)
                        this.router.navigate(['/books'])
                    }
                },
                err => {
                    if(err.status === 401){
                        toastr.error("Invalid username or password")
                        this.error = true;
                        console.log(this.error)
                    }
                }
            )
        }else {
            toastr.error("username or password cannot be empty")
        }
        
    }
}
