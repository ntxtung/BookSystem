import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { from } from 'rxjs';

import { UserModule } from './user/user.module';
import { BookModule } from './book/book.module';
import { AdminModule } from './admin/admin.module';
import { TemplateModule } from './template/template.module';

import { UserApiService } from './services/user-services/user-api-service.service';
import { BookApiService } from './services/book-services/book-api-service.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app.routes';

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
        HttpClientModule,
        RouterModule.forRoot(appRoutes, {useHash: true})
    ],
    providers: [
        UserApiService,
        BookApiService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
