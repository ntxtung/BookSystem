import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'user-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    loginUserData = {}
    constructor() { }

    ngOnInit() {
    }

    login(){
        console.log(this.loginUserData)
    }
}
