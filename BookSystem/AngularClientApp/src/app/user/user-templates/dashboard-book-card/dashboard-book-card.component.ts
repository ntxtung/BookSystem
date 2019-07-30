import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'user-dashboard-book-card',
    templateUrl: './dashboard-book-card.component.html',
    styleUrls: ['./dashboard-book-card.component.css']
})
export class DashboardBookCardComponent implements OnInit {

    @Input()
    book;
    
    constructor() { }

    ngOnInit() {
    }

}
