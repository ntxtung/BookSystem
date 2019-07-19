import { Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsersListComponent } from './users-list/users-list.component';

export const adminRoutes : Routes = [
    {path: "users", component: UsersListComponent}
]