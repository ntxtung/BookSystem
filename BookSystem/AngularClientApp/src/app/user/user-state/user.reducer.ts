import { User } from 'src/app/models/user.model';
import * as fromRoot from "../../state/app.state"
export interface UserState {
    user: User;
    isLogged: boolean;
    token: string;
}

export interface AppState extends fromRoot.AppState {
    users: UserState
}

export const initialUserState: UserState = {
    user: null,
    isLogged: false,
    token: null
}

export function userReducer(state=initialUserState, action): UserState {
    switch(action.type){
        case "LOGIN": {
            return {
                ...state,
                user: action.payload.user,
                isLogged: true,
                token: action.payload.user.token
            };
        }
        case "LOGOUT": {
            return {
                ...state,
                user: action.payload.user,
                isLogged: action.payload.isLogged,
                token: null
            };
        }
        default: {
            return state;
        }
    }
}