import { Component, OnInit } from '@angular/core';
import { BookApiService } from 'src/app/services/book-services/book-api-service.service';
import { Router } from '@angular/router';

@Component({
    selector: 'book-books-list',
    templateUrl: './books-list.component.html',
    styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {

    books: any;
    constructor(private bookApiService: BookApiService, private router: Router) { }

    ngOnInit() {
        this.bookApiService.getBooks().subscribe(
            res => {
                this.books = res;
            },
            // 401 Unauthorized error
            err => {
                this.router.navigate(["/login"])
            }
        )
    }

}
