import { Routes } from "@angular/router"
import { WelcomeComponent } from './template/welcome/welcome.component';
import { PageNotFoundComponent } from './template/page-not-found/page-not-found.component';

export const appRoutes : Routes = [
    {path: "", component: WelcomeComponent},
    {path: "**", component: PageNotFoundComponent}
]