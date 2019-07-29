import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from "@angular/forms"

import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule } from '@angular/router';
import { userRoutes } from './user.routes';
import { HttpClientModule } from '@angular/common/http';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { UserFundedBooksComponent } from './user-funded-books/user-funded-books.component';
import { UserRentedBooksComponent } from './user-rented-books/user-rented-books.component';
import { DashboardMenuComponent } from './user-templates/dashboard-menu/dashboard-menu.component';
import { DashboardContentComponent } from './user-templates/dashboard-content/dashboard-content.component';



@NgModule({
    declarations: [
        LoginComponent,
        RegisterComponent,
        UserDashboardComponent,
        UserProfileComponent,
        UserFundedBooksComponent,
        UserRentedBooksComponent,
        DashboardMenuComponent,
        DashboardContentComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        HttpClientModule,
        RouterModule.forChild(userRoutes)
    ]
})
export class UserModule { }
