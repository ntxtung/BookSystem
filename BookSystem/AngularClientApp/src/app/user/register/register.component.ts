import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'user-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

    loginRegisterData: any = {
        email: null,
        username: null,
        password: null,
        repassword: null,
    }
    passwordMatching: boolean = true
    constructor() { }

    ngOnInit() {
    }

    checkConfirmPassword(){
        if(this.loginRegisterData.password != this.loginRegisterData.repassword){
            this.passwordMatching = false;
        }
        else {
            this.passwordMatching = true;
        }
        console.log("passwordMatching: "+this.passwordMatching)
    }

}
