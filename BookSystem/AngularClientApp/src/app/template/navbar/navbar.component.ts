import { Component, OnInit, OnChanges, SimpleChanges, Input } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'template-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

    token: string;
    isLogged: boolean;

    constructor(private userAuthenticationService: UserAuthenticationService) {
    }

    ngOnInit() {
        this.changeVariables()
    }

    async logout(){
        await this.userAuthenticationService.logout()
        this.changeVariables()
    }

    private changeVariables(){
        this.token = localStorage.getItem("token")
        this.isLogged = (this.token != null)? true : false;
    }
}
