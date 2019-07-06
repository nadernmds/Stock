import React, { Component } from "react";
import NavBar from "./Widgets/NavBar/NavBar";
import { Container } from "@material-ui/core";
import UserGroup from "./Pages/UserGroup/UserGroup";

export class Layout extends Component {
  static displayName = Layout.name;

  render() {
    return (
      <div>
        <NavBar />
        <div className="uk-grid-small" data-uk-drid>
          <Container>
            <UserGroup />
          </Container>
        </div>
      </div>
    );
  }
}
