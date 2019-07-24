import { Component, OnInit } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { User } from 'src/app/models/user';

declare let toastr

@Component({
    selector: 'user-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    loginUserData = {}
    loggedUser : User = new User()
    isLogged = false;
    constructor(private userAuthenticationService : UserAuthenticationService) { }

    ngOnInit() {
    }

    login(){
        this.userAuthenticationService.loginUserWithBody(this.loginUserData).subscribe(
            res => {
                if(res){
                    toastr.success("login success as "+res.firstname+" "+res.lastname)
                    this.isLogged = true;
                    this.loggedUser.id = res.id
                    this.loggedUser.token = res.token
                    console.log(this.loggedUser)
                    localStorage.setItem('token', res.token)
                }else{
                    toastr.error("invalid username or password")
                }
            },
            err => console.log(err)
        )
    }
}
