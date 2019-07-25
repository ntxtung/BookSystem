import { Component, OnInit } from '@angular/core';
import { BookApiService } from 'src/app/services/book-services/book-api-service.service';

@Component({
    selector: 'book-books-list',
    templateUrl: './books-list.component.html',
    styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {

    books : any;
    constructor(private bookApiService: BookApiService) { }

    ngOnInit() {
        this.bookApiService.getBooks().subscribe(res => {
            this.books = res;
        })
    }

}
