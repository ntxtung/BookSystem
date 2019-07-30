import { Component, OnInit } from '@angular/core';
import { BookApiService } from 'src/app/services/book-services/book-api-service.service';
import { UserAuthorizationService } from 'src/app/services/user-services/user-authorization.service';

@Component({
    selector: 'user-dashboard',
    templateUrl: './user-dashboard.component.html',
    styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {


    constructor(private userAuthorizationService: UserAuthorizationService) { }

    ngOnInit() {
        this.userAuthorizationService.checkAuthorization();
    }

}
