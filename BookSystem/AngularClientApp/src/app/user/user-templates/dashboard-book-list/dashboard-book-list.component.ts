import { Component, OnInit, Input } from '@angular/core';
import * as $dollar from 'jquery';
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
        $dollar(document).ready(function () {
            $dollar("button").click(function () {
                $dollar('.ui.modal').modal('show');
                console.log("modal show: true")
            });
        });
    }
}
