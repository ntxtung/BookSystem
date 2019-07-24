import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksListComponent } from './books-list/books-list.component';
import { BookDetailComponent } from './detail/detail.component';



@NgModule({
    declarations: [
        BooksListComponent,
        BookDetailComponent
    ],
    imports: [
        CommonModule
    ]
})
export class BookModule { }
