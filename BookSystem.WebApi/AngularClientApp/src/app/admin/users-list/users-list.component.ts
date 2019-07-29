import { Component, OnInit } from '@angular/core';
import { UserApiService } from 'src/app/services/user-services/user-api-service.service';

@Component({
    selector: 'admin-users-list',
    templateUrl: './users-list.component.html',
    styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

    users : any
    constructor(private userApiService : UserApiService) { }

    ngOnInit() {
        this.userApiService.getUsers().subscribe(data => {
            console.log(data)
            this.users = data
        })
    }

}
