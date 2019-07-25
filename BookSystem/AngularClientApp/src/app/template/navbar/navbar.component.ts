import { Component, OnInit, Input } from '@angular/core';

@Component({
    selector: 'template-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

    // @Input()
    // isLogged

    constructor() { }

    ngOnInit() {
        // console.log("is logged - "+this.isLogged)
    }

}
