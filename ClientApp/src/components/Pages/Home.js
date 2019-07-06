import React, { Component } from 'react';
import Bank from './Bank/Bank';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
<Bank/>

      </div>
    );
  }
}
