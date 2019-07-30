import { ActionReducerMap, ActionReducer, MetaReducer } from '@ngrx/store';
import { userReducer } from '../user/user-state/user.reducer';
import { localStorageSync } from "ngrx-store-localstorage"

export interface AppState{}

export const reducers: ActionReducerMap<AppState> = {
    users: userReducer
}

export function localStorageSyncRedcuer(reducer: ActionReducer<any>): ActionReducer<any> {
    return localStorageSync({
        keys: ["users"],
        rehydrate: true
    })(reducer);
}

export const metaReducers: Array<MetaReducer<any, any>> = [localStorageSyncRedcuer];