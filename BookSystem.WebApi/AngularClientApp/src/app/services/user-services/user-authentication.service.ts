import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UserAuthenticationService {

    private loginUrl = "http://localhost:5000/api/auth/login"
    private loginUrlWithParameters : string
    constructor(private httpClient : HttpClient) { }

    loginUserWithParameters(user){
        this.loginUrlWithParameters = this.loginUrl+"?username="+user.email+"&password="+user.password
        console.log(this.loginUrlWithParameters)
        return this.httpClient.post<any>(this.loginUrlWithParameters, null)
    }
    
    loginUserWithBody(inputData){
        return this.httpClient.post<any>(this.loginUrl, inputData)
    }

    logout(){
        localStorage.removeItem("token")
    }
}
