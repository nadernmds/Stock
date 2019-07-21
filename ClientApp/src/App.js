import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import { Home } from "./components/Pages/Home";
import { FetchData } from "./components/FetchData";
import { Counter } from "./components/Counter";
import UserGroup from "./components/Pages/UserGroup/UserGroup";
import User from "./components/Pages/User/User";
import Bank from "./components/Pages/Bank/Bank";
import Faq from "./components/Pages/Faq/Faq";
import Stock from "./components/Pages/Stock/Stock";
import Company from "./components/Pages/Company/Company";
import Transfer from "./components/Pages/Transfer/Transfer";
import Notification from "./components/Pages/Notification/Notification";
import State from "./components/Pages/State/State";
import Login from "./components/Pages/Login/Login";
import { Divider } from "@material-ui/core";
import Test from "./components/Pages/Test/Test";

export default class App extends Component {
  static displayName = App.name;
  state = { loggedIn: false };
  render() {
    if (this.state.loggedIn) {
      return (
        <Layout>
          <Route exact path="/userGroup" component={UserGroup} />
          <Route path="/user" component={User} />
          <Route path="/bank" component={Bank} />
          <Route path="/faq" component={Faq} />
          <Route path="/stock" component={Stock} />
          <Route path="/company" component={Company} />
          <Route path="/transfer" component={Transfer} />
          <Route path="/notification" component={Notification} />
          <Route path="/state" component={State} />
          <Route path="/login" component={Login} />
          <Route path="/test" component={Test} />

        </Layout>
      );
    } else {
      return <Login />;
    }
  }

  componentDidMount() {
    fetch("api/user/login")
      .then(c => c.json())
      .then(c => {
        this.setState({ loggedIn: c });
      });
  }
}
