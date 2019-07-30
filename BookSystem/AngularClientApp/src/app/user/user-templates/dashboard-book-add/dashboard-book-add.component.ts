import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
    selector: 'user-dashboard-book-add',
    templateUrl: './dashboard-book-add.component.html',
    styleUrls: ['./dashboard-book-add.component.css']
})
export class DashboardBookAddComponent implements OnInit {

    bookInsertData = {
        title: null,
        author: null,
        userFundId: null
    }
    constructor(private dialogRef: MatDialogRef<DashboardBookAddComponent>) { }

    ngOnInit() {
    }

    onSubmit() {
        this.onClose();
    }

    onClose() {
        this.dialogRef.close();
    }

}
