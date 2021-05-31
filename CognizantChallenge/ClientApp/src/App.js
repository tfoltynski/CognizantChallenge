import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Solve } from './components/Solve';
import { Top3 } from './components/Top3';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Solve} />
        <Route path='/top3' component={Top3} />
      </Layout>
    );
  }
}
