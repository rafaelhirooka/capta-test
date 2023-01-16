import React from 'react';
import {Routes, Route} from 'react-router-dom';

import {Client} from './pages/Client/Client';

import {DefaultLayout} from './layouts/DefaultLayout';

export function Router() {
  return (
    <Routes>
      <Route path="/" element={<DefaultLayout />}>
        <Route path="/" element={<Client />} />
      </Route>
    </Routes>
  )
}