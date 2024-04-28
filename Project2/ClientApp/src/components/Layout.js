import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { SideNav } from './SideNav'

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
      return (
        <div className="page-wrapper">
        <NavMenu />
        <div className="wrapper">
          <SideNav />
          <div className="container-fluid main-section px-4 py-4">
            {this.props.children}
          </div>
        </div>
        
      </div>

    );
  }
}
