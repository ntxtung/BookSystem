import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { HttpClientModule } from "@angular/common/http"

import { UserModule } from './user/user.module';
import { BookModule } from './book/book.module';
import { AdminModule } from './admin/admin.module';
import { TemplateModule } from './template/template.module';

import { UserApiService } from './services/user-services/user-api-service.service';
import { BookApiService } from './services/book-services/book-api-service.service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        UserModule,
        AdminModule,
        BookModule,
        TemplateModule,
        HttpClientModule
    ],
    providers: [
        UserApiService,
        BookApiService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
