import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomepageComponent } from "./homepage/homepage.component";
import { LoginComponent } from "./login/login.component";

@NgModule({
    declarations: [
        HomepageComponent,
        LoginComponent
    ],
    imports: [
        CommonModule
    ],
    exports: [
        HomepageComponent
    ]
})
export class BooksystemModule { }
