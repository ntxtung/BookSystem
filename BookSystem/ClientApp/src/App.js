import React from 'react';
import { Route } from 'react-router-dom';
import AuthPage from './pages/AuthPage';
import MainPage from './pages/MainPage'

export default class App extends React.Component {
  componentDidMount(){
    // Some initialize
    // Check token ... blabla
  }
  render() {
    return (
      <div>
        <Route exact path='/auth' component={AuthPage} />
        <Route path='/' component={MainPage} />
        
        
      </div>
    )
  }
}