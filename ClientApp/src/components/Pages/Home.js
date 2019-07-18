import React, { Component } from "react";
import Bank from "./Bank/Bank";
import User from "./User/User";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <User />
      </div>
    );
  }
}
