import { User } from 'src/app/models/user.model';
import * as fromRoot from "../../state/app.state"
export interface UserState {
    user: User;
    loggedIn: boolean;
    token: string;
}

export interface AppState extends fromRoot.AppState {
    users: UserState
}

export const initialUserState: UserState = {
    user: null,
    loggedIn: false,
    token: null
}

export function UserReducer(state=initialUserState, action): UserState {
    switch(action.type){
        case "LOGIN": {
            return {
                ...state,
                user: action.payload.user,
                loggedIn: true,
                token: action.payload.token
            };
        }
        
        default: {
            return state;
        }
    }
}