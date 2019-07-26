import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms"

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
import { UserAuthenticationService } from './services/user-services/user-authentication.service';
import { EffectsModule } from '@ngrx/effects';
import { AuthEffects } from './store/effects/auth.effects';
import { UserAuthorizationService } from './services/user-services/user-authorization.service';

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
        FormsModule,
        // EffectsModule.forRoot([AuthEffects]),
        RouterModule.forRoot(appRoutes, {useHash: true})
    ],
    providers: [
        UserApiService,
        BookApiService,
        UserAuthenticationService,
        UserAuthorizationService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
