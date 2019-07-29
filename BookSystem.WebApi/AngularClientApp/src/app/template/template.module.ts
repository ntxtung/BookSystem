import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WelcomeComponent } from './welcome/welcome.component';
import { NavbarComponent } from './navbar/navbar.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { TemplateComponent } from './template/template.component';
import { RouterModule } from '@angular/router';
import { ContentComponent } from './content/content.component';



@NgModule({
    declarations: [
        WelcomeComponent,
        NavbarComponent,
        PageNotFoundComponent,
        TemplateComponent,
        ContentComponent
    ],
    imports: [
        CommonModule,
        RouterModule
    ],
    exports: [
        TemplateComponent
    ]
})
export class TemplateModule { }
