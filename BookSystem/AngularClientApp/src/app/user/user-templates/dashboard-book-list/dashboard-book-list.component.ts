import { Component, OnInit, Input } from '@angular/core';

declare var $ : any;
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
        $(document).ready(function () {
            $("button").click(function () {
                $('.ui.basic.modal').modal("show");
            });
        });
    }
}
