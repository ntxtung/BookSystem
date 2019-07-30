import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import * as materialModule from '@angular/material';



@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        materialModule.MatInputModule,
        materialModule.MatGridListModule,
        materialModule.MatDialogModule,
        materialModule.MatTabsModule,
        materialModule.MatFormFieldModule,
        materialModule.MatButtonModule
    ],
    exports: [
        materialModule.MatInputModule,
        materialModule.MatGridListModule,
        materialModule.MatDialogModule,
        materialModule.MatTabsModule,
        materialModule.MatFormFieldModule,
        materialModule.MatButtonModule
    ]
})
export class MaterialModule { }
