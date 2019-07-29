export default (loggedUser = null, action) => {
  switch (action.type){

      case 'AUTH_LOGIN':
          if (action.payload.id != null && loggedUser == null){
            // alert("Login Successful, now redirect to HomePage")
            // console.log("User Login successful: ", action.payload)
            return action.payload;
          }
          return loggedUser

      case 'USER_REGISTER':
          if (action.payload.id != null && loggedUser == null){
            // alert("Register Successful, now redirect to HomePage")
            // console.log("User Logged In by register successful: ", action.payload)
            return action.payload;
          }
          return null
      case 'AUTH_LOGOUT':
        return null
      default:
          return null
  }
}