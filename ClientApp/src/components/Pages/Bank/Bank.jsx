import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
class Bank extends Component {
  state = {};
  columns = [{ title: "نام بانک", field: "bankName" }];
  render() {
    return (
      <div>
        <Table
          url="api/bank"
          primaryKey={"bankId"}
          columns={this.columns}
          title="بانک ها"
          primaryKey='bankId'
        />
      </div>
    );
  }
}

export default Bank;
