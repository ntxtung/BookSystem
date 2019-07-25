import { Component, OnInit, Input } from '@angular/core';
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { Router } from '@angular/router';

@Component({
    selector: 'template-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

    @Input()
    isLogged

    constructor(private userAuthenticationService: UserAuthenticationService, private router: Router) {
    }

    ngOnInit() {
        console.log("is logged - "+this.isLogged)
    }

    logout(){
        this.userAuthenticationService.logout()
        // this.router.navigate(["/login"])
    }

}
