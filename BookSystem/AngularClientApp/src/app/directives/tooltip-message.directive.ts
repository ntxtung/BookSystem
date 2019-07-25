import { Directive, ElementRef, Renderer, Input, HostListener } from '@angular/core';

@Directive({
    selector: '[appTooltipMessage]'
})
export class TooltipMessageDirective {

    @Input("appTooltipMessage") error: string;

    constructor(private el: ElementRef, private renderer: Renderer) {
        console.log("test: "+this.error)
        el.nativeElement.style.backgroundColor="blue";
    }

    @HostListener('mouseenter') onMouseEnter() {
        console.log(this.error)
    }

}
