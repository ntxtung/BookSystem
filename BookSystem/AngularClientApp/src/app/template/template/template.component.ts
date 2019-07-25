import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-template',
    templateUrl: './template.component.html',
    styleUrls: ['./template.component.css']
})
export class TemplateComponent implements OnInit {

    token: string

    constructor() { }

    ngOnInit() {
        this.token = localStorage.getItem("token")
        console.log("token - "+this.token)
    }

}