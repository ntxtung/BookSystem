import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TooltipMessageDirective } from './tooltip-message.directive';

@NgModule({
    declarations: [
        TooltipMessageDirective
    ],
    imports: [
        CommonModule
    ],
    exports: [
        TooltipMessageDirective
    ]
})
export class DirectivesModule { }
