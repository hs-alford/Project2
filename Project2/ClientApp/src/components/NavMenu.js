import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render() {
    return (
        <header>
            <Navbar className="navbar-expand-sm navbar-toggleable-sm navbar-dark box-shadow px-3">
                <NavbarBrand tag={Link} to="/">BPM Application</NavbarBrand>
                <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                    <ul className="navbar-nav flex-grow">
                        <NavItem>
                            <NavLink tag={Link} className="text-light" to="/">Home</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="text-light" to="/counter">Counter</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="text-light" to="/fetch-data">Fetch data</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="text-light" to="/employee-list">Employees</NavLink>
                        </NavItem>
                        <NavItem>
                            <NavLink tag={Link} className="text-light" to="/add-employee">Add Employee</NavLink>
                        </NavItem>
                        <LoginMenu>
                        </LoginMenu>
                    </ul>
                </Collapse>
            </Navbar>
       
      </header>
    );
  }
}
