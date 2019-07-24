import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'book-detail',
    templateUrl: './detail.component.html',
    styleUrls: ['./detail.component.css']
})
export class BookDetailComponent implements OnInit {

    @Input()
    book;

    constructor() { }

    ngOnInit() {
    }

}
