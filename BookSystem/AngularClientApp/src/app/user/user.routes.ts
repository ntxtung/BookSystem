import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { BooksListComponent } from '../book/books-list/books-list.component';
import { UserDashboardComponent } from './user-dashboard/user-dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { UserBooksComponent } from './user-books/user-books.component';

export const userRoutes : Routes = [
    {path: "register", component: RegisterComponent},
    {path: "login", component: LoginComponent},
    {path: "books", component: BooksListComponent},
    {path: "dashboard", component: UserDashboardComponent, children: [
        {path: "profile", component: UserProfileComponent},
        {path: "user-books", component: UserBooksComponent}
    ]}
]