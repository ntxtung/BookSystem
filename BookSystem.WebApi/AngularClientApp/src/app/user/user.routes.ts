import { Routes } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { BooksListComponent } from '../book/books-list/books-list.component';

export const userRoutes : Routes = [
    {path: "register", component: RegisterComponent},
    {path: "login", component: LoginComponent},
    {path: "books", component: BooksListComponent}
]