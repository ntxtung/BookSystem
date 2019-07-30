import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserAuthorizationService } from '../user-services/user-authorization.service';
import { Book } from 'src/app/models/book.model';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user.model';

@Injectable({
    providedIn: 'root'
})
export class BookApiService {
    private BASE_URL = "http://localhost:5000";

    constructor(private httpClient: HttpClient, private userAuthorizationService: UserAuthorizationService) { }

    getBooks(): Observable<Book[]> {
        return this.httpClient.get<Book[]>(`${this.BASE_URL}/api/books`, { headers: this.userAuthorizationService.setHeader()});
    }

    getUserFundedBooks(user: User): Observable<Book[]> {
        return this.httpClient.get<Book[]>(`${this.BASE_URL}/api/users/`+user.id+`/fund/books?pageSize=20`, { headers: this.userAuthorizationService.setHeader()})
    }

    postBook(book): Observable<Book>{
        return this.httpClient.post<any>(`${this.BASE_URL}/api/books/`, book, { headers: this.userAuthorizationService.setHeader()})
    }

    deleteBook(book){
        
    }
}
