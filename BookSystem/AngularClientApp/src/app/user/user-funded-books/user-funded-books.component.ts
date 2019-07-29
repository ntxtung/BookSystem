import { Component, OnInit } from '@angular/core';
import { BookApiService } from 'src/app/services/book-services/book-api-service.service';
import { Observable } from 'rxjs';
import { Book } from 'src/app/models/book.model';
import { User } from 'src/app/models/user.model';

@Component({
    selector: 'user-funded-books',
    templateUrl: './user-funded-books.component.html',
    styleUrls: ['./user-funded-books.component.css']
})
export class UserFundedBooksComponent implements OnInit {

    books: Book[]
    user: User
    constructor(private bookApiService: BookApiService) { }

    ngOnInit() {
        this.user = JSON.parse(localStorage.getItem("user"));
        this.bookApiService.getUserFundedBooks(this.user).subscribe(
            books => {
                this.books = books;
            }
        )
    }

}
