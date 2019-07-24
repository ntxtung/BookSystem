import { Injectable } from "@angular/core";
import { Actions, Effect, ofType } from "@ngrx/effects"
import { UserAuthenticationService } from 'src/app/services/user-services/user-authentication.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthEffects{
    constructor(
        private actions : Actions,
        private userAuththenticationService : UserAuthenticationService,
        private router : Router
    ){}
    
}