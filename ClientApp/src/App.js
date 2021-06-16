import React, { Component } from 'react';
import {Container} from 'reactstrap'
import {PassportForm} from "./PassportForm"
import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <div className="main">
        <Container fluid='sm'>
          <PassportForm />
        </Container>
      </div>
    );
  }
}
