import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersListComponent } from './users-list/users-list.component';
import { DoashboardComponent } from './doashboard/doashboard.component';
import { RouterModule } from '@angular/router';
import { adminRoutes } from './admin.routes';




@NgModule({
    declarations: [
        UsersListComponent,
        DoashboardComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forRoot(adminRoutes)
    ],
    exports: [
        DoashboardComponent
    ]
})
export class AdminModule { }
