import localhost5000 from '../apis/localhost5000'

const connectedHost = localhost5000

export const doAuthLogin = (userData) => async dispatch => {
  const response = await connectedHost({
    method: "POST",
    url: '/auth/login',
    headers: {},
    params: {
      username: userData.username,
      password: userData.password
    }
  });
  console.log(response)
  dispatch({type: 'AUTH_LOGIN', payload: response.data})
}

export const doUserRegister = (userData) => async dispatch => {
  const response = await connectedHost({
    method: "POST",
    url: '/users',
    headers: {},
    data: {
      username: userData.username,
      firstname: userData.firstname,
      lastname: userData.lastname,
      email: userData.email,
      password: userData.password
    }
  })
  dispatch({type: 'USER_REGISTER', payload: response.data})
}

export const doLogOut = () => {
  return {
    type: 'AUTH_LOGOUT',
    payload: true
  }
}