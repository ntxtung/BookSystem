import { Directive, ElementRef, Renderer2, Input, HostListener } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Directive({
    selector: '[appTooltipMessage]'
})
export class TooltipMessageDirective {

    @Input("appTooltipMessage")
    error: boolean;

    snackBar: MatSnackBar;

    constructor(private el: ElementRef, private renderer: Renderer2) {
        this.generateTooltip(this.error)
    }

    private generateTooltip(nullError: boolean) {
        if (nullError) {
            this.snackBar.open("Error", "blah", {
                duration: 2000,
            });
            this.renderer.appendChild(this.el.nativeElement, this.snackBar)
        }
    }



}
