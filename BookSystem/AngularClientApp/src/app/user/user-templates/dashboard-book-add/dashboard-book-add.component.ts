import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Store, select } from '@ngrx/store';
import { BookApiService } from 'src/app/services/book-services/book-api-service.service';

@Component({
    selector: 'user-dashboard-book-add',
    templateUrl: './dashboard-book-add.component.html',
    styleUrls: ['./dashboard-book-add.component.css']
})
export class DashboardBookAddComponent implements OnInit {

    bookInsertData = {
        title: null,
        author: null,
        usersFundId: null
    }
    constructor(
        private dialogRef: MatDialogRef<DashboardBookAddComponent>,
        private store: Store<any>,
        private bookApiService: BookApiService
    ) { }

    ngOnInit() {
        this.store.pipe(select("users")).subscribe(
            users => {
                if(users){
                    this.bookInsertData.usersFundId = users.user.id;
                }
            }
        )
    }

    onSubmit() {
        this.bookApiService.postBook(this.bookInsertData).subscribe()
        this.onClose();
    }

    onClose() {
        this.dialogRef.close();
    }

}
