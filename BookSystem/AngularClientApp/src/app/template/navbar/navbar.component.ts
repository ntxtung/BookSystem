import { Component, OnInit, OnChanges, SimpleChanges, Input } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { Router } from '@angular/router';
import { UserAuthorizationService } from 'src/app/services/user-services/user-authorization.service';

@Component({
    selector: 'template-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

    token: string;
    isLogged: boolean;

    constructor(private userAuthenticationService: UserAuthenticationService, private userAuthorizationService: UserAuthorizationService) {
    }

    ngOnInit() {
        this.isLogged = this.userAuthorizationService.checkAuthorization()
        console.log("navbar-isLogged: " + this.isLogged)
    }

    async logout(){
        await this.userAuthenticationService.logout()
        this.isLogged = this.userAuthorizationService.checkAuthorization()
    }
}
