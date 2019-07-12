import React from 'react';
import thunk from 'redux-thunk'
import ReactDOM from 'react-dom';

import { createStore, applyMiddleware } from 'redux'

import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';

import registerServiceWorker from './registerServiceWorker';
import App from './App';
import reducers from './reducers'

const store = createStore(
  reducers, 
  composeWithDevTools(),
  applyMiddleware(thunk)
);

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById('root')
);

registerServiceWorker();
