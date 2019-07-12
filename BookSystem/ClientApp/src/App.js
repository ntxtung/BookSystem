import React from 'react';
import { Route } from 'react-router-dom';
import AuthPage from './pages/AuthPage';
import HomePage from './pages/MainPage'

export default class App extends React.Component {
  render() {
    return (
      <div>
        <Route exact path='/' component={HomePage} />
        <Route path='/auth' component={AuthPage} />
      </div>
    )
  }
}