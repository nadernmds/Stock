import React, { Component } from "react";
import UserCreate from "./UserCreate";
class User extends Component {
  state = {
    num: 100
  };
  render() {
    return (
      <div>
        <UserCreate
          update={c => {
            this.setState({ ...c });
          }}
          value={this.state.num}
        />
      </div>
    );
  }
}

export default User;
