import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
class UserGroup extends Component {
  state = {};
  columns = [{ title: "گروه کاربری", field: "groupName" }];
  render() {
    return (
      <Table
        title="گروه کاربری"
        primaryKey="userGroupId"
        columns={this.columns}
        url="api/usergroup"
      />
    );
  }
}

export default UserGroup;
