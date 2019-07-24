import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class BookApiService {
    private BASE_URL = "http://localhost:5000"
    constructor(private httpClient: HttpClient) { }

    getBooks(){
        return this.httpClient.get(`${this.BASE_URL}/api/books`);
    }
}
