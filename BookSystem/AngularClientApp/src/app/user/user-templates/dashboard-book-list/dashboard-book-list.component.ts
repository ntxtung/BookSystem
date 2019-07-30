import { Component, OnInit, Input } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DashboardBookAddComponent } from '../dashboard-book-add/dashboard-book-add.component';

declare var $ : any;
@Component({
    selector: 'user-dashboard-book-list',
    templateUrl: './dashboard-book-list.component.html',
    styleUrls: ['./dashboard-book-list.component.css']
})
export class DashboardBookListComponent implements OnInit {

    @Input()
    books;

    constructor(private dialog: MatDialog) { }

    ngOnInit() {
    }

    addBook(){
        const dialogConfig = new MatDialogConfig();
        //disableClose avoid closing modal by clicking outside
        dialogConfig.disableClose = true;
        dialogConfig.autoFocus = true;
        this.dialog.open(DashboardBookAddComponent, dialogConfig)
    }
}
