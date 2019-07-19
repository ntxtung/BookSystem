import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { from } from 'rxjs';
import { UserModule } from './user/user.module';
import { BookModule } from './book/book.module';
import { AdminModule } from './admin/admin.module';
import { TemplateModule } from './template/template.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        UserModule,
        AdminModule,
        BookModule,
        TemplateModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
