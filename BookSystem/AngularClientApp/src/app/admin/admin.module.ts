import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule } from '@angular/router';
import { adminRoutes } from './admin.routes';
import { UsersListComponent } from './users-list/users-list.component';

@NgModule({
    declarations: [
        DashboardComponent,
        UsersListComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(adminRoutes)
    ],
    exports: [
        DashboardComponent
    ]
})
export class AdminModule { }
