import React, { Component } from "react";
import ApiTable from "../../Widgets/Table/ApiTable";
class State extends Component {
  state = {};
  columns = [
    {
      field: "stateName",
      title: "نام استان"
    }
  ];
  render() {
    return (
      <div>
        <ApiTable
          url="api/state"
          title="استان ها"
          primaryKey="stateId"
          columns={this.columns}
        />
      </div>
    );
  }
}

export default State;
