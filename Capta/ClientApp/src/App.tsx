import React from 'react';

import {BrowserRouter} from 'react-router-dom';

import { Router } from './Router';

import {GlobalStyle} from './styles/global';

import 'devextreme/dist/css/dx.material.blue.dark.css';

export function App() {
  return (
    <BrowserRouter>
      <Router />
      <GlobalStyle />
    </BrowserRouter>
  )
}