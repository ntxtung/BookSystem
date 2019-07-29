import { combineReducers } from 'redux'
import authLoggedInUser from './authLoggedInUser'

export default combineReducers({
  loggedInUser: authLoggedInUser
})