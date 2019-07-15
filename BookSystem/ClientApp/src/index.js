import React from 'react';
import thunk from 'redux-thunk'
import ReactDOM from 'react-dom';

import { createStore, applyMiddleware } from 'redux'
//----------------------Save state to local storge------------------------------
import { persistStore, persistReducer } from 'redux-persist';
import storage from 'redux-persist/lib/storage';
// import autoMergeLevel2 from 'redux-persist/lib/stateReconciler/autoMergeLevel2';
import { PersistGate } from 'redux-persist/lib/integration/react';
//------------------------------------------------------------------------------

import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import { composeWithDevTools } from 'redux-devtools-extension';

import registerServiceWorker from './registerServiceWorker';
import App from './App';
import reducers from './reducers'

//--------------------Store and persistor config-------------------------
const persistConfig = { 
  key: 'root',
  storage: storage,
  whitelist: ['loggedInUser']
  // stateReconciler: autoMergeLevel2
}

const pReducer = persistReducer(persistConfig, reducers)

const store = createStore(
  pReducer, 
  composeWithDevTools({
    name: `Redux`,
    realtime: true,
    trace: true,
    traceLimit: 25
  })(),
  applyMiddleware(thunk)
  );
  
  const persistor = persistStore(store)
//----------------------------END-----------------------------------------

ReactDOM.render(
  <Provider store={store}>
    <PersistGate loading={<div>Loading...</div>} persistor={persistor}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </PersistGate>
  </Provider>,
  document.getElementById('root')
);

registerServiceWorker();
