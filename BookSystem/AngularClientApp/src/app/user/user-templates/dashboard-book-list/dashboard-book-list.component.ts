import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'user-dashboard-book-list',
    templateUrl: './dashboard-book-list.component.html',
    styleUrls: ['./dashboard-book-list.component.css']
})
export class DashboardBookListComponent implements OnInit {

    @Input()
    books;
    
    constructor() { }

    ngOnInit() {
    }

}
