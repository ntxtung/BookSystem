import { Component, OnInit, SimpleChanges, AfterViewInit } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { Router } from '@angular/router';
import { UserAuthorizationService } from 'src/app/services/user-services/user-authorization.service';
import { User } from 'src/app/models/user.model';
import { Store, select } from '@ngrx/store';

@Component({
    selector: 'template-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

    token: string;
    isLogged: boolean;
    user : any;
    users: any;

    constructor(
        private userAuthenticationService: UserAuthenticationService,
        private userAuthorizationService: UserAuthorizationService,
        private store: Store<any>,
        private router: Router) {
    }

    ngOnInit() {
        // this.isLogged = this.userAuthorizationService.checkAuthorization()
        // this.getCurrentUser()
        this.store.pipe(select("users")).subscribe(
            users => {
                if(users){
                    console.log("users-state: "+users)
                    this.isLogged = users.isLogged
                    this.user = users.user
                }
            }
        )
    }
    
    getCurrentUser(){
        this.user = JSON.parse(localStorage.getItem("user"))
    }

    async logout(){
        // await this.userAuthenticationService.logout()
        // this.isLogged = this.userAuthorizationService.checkAuthorization()
        this.router.navigate(["/login"])
    }

}
