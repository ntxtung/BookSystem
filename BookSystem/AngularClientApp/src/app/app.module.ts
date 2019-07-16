import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BooksystemModule } from "../booksystem/booksystem.module";

import { AppComponent } from './app.component';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BooksystemModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
