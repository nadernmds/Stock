import React, { Component } from "react";
import NavBar from "./Widgets/NavBar/NavBar";
import MyDrawer from './Widgets/Drawer/Drawer'
import Bank from "./Pages/Bank/Bank";
import User from "./Pages/User/User";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <NavBar />
        <div className="uk-grid-small" data-uk-drid>
            <MyDrawer>
              {this.props.children}
            </MyDrawer>
        </div>
      </div>
    );
  }
}
