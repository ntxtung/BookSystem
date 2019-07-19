import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserApiService {
    users : any
    constructor(private httpClient : HttpClient) { }

    getUsers(){
        this.users = this.httpClient.get("http://localhost:5000/api/users")
        // this.users=[
        //     {
        //         "id": 1,
        //         "username": "ntxtung",
        //         "firstname": "Nguyễn Thanh",
        //         "lastname": "Xuân Tùng",
        //         "email": "xuantung.1998@gmail.com",
        //         "token": null
        //     },
        //     {
        //         "id": 2,
        //         "username": "baorchaau",
        //         "firstname": "Dương",
        //         "lastname": "Bảo Châu",
        //         "email": "baochauduong94@gmail.com",
        //         "token": null
        //     }
        // ]
        return this.users
    }
}
