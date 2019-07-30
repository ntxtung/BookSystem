import { Component, OnInit } from '@angular/core';
import { BookApiService } from 'src/app/services/book-services/book-api-service.service';

@Component({
    selector: 'user-dashboard',
    templateUrl: './user-dashboard.component.html',
    styleUrls: ['./user-dashboard.component.css']
})
export class UserDashboardComponent implements OnInit {


    constructor(private bookApiService: BookApiService) { }

    ngOnInit() {
        
    }

}
