import React, { Component, Fragment } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
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
import withAuth from "./withAuth";
import InstallmentTemplate from "./components/Pages/InstallmentTemplate/InstallmentTemplate";
import AuthService from "./AuthService";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.Path.bind(this);
  }
  static displayName = App.name;
  state = {};
  // render(){
  //   return ( <div>pep</div>);
  // }
  render() {
    const Path = this.Path;
    return (
      <Layout>
        <Route path="/login" component={Login} />
        <Path path="/user" component={User} />
        <Path exact path="/userGroup" component={UserGroup} />
        <Path path="/bank" component={Bank} />
        <Path path="/faq" component={Faq} />
        <Path path="/stock" component={Stock} />
        <Path path="/company" component={Company} />
        <Path path="/transfer" component={Transfer} />
        <Path path="/notification" component={Notification} />
        <Path path="/state" component={State} />
        <Path path="/installment" component={InstallmentTemplate} />
        <Path path="/test" component={Test} />
      </Layout>
    );
  }
  Path(props) {
    return (
      <Route exact path={props.path} component={withAuth(props.component)} />
    );
  }
}
