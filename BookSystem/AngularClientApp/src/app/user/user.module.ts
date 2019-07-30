import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from "@angular/forms"

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
import { userRoutes } from './user.routes';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import * as fromUser from './user-state/user.reducer';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { UserFundedBooksComponent } from './user-funded-books/user-funded-books.component';
import { UserRentedBooksComponent } from './user-rented-books/user-rented-books.component';
import { DashboardMenuComponent } from './user-templates/dashboard-menu/dashboard-menu.component';
import { DashboardContentComponent } from './user-templates/dashboard-content/dashboard-content.component';
import { UserBooksComponent } from './user-books/user-books.component';
import { DashboardBookCardComponent } from './user-templates/dashboard-book-card/dashboard-book-card.component';
import { DashboardBookListComponent } from './user-templates/dashboard-book-list/dashboard-book-list.component';
import { DashboardBookAddComponent } from './user-templates/dashboard-book-add/dashboard-book-add.component';
import { DashboardBookEditComponent } from './user-templates/dashboard-book-edit/dashboard-book-edit.component';
import { MaterialModule } from '../material/material.module';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

@NgModule({
    declarations: [
        LoginComponent,
        RegisterComponent,
        UserDashboardComponent,
        UserProfileComponent,
        UserFundedBooksComponent,
        UserRentedBooksComponent,
        DashboardMenuComponent,
        DashboardContentComponent,
        UserBooksComponent,
        DashboardBookCardComponent,
        DashboardBookListComponent,
        DashboardBookAddComponent,
        DashboardBookEditComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forChild(userRoutes),
        StoreModule.forFeature("users", fromUser.userReducer),
        MaterialModule,
        MDBBootstrapModule.forRoot()
    ],

    // entry components are the those that gonna be showed in modals
    entryComponents: [
        DashboardBookAddComponent
    ]
})
export class UserModule { }
