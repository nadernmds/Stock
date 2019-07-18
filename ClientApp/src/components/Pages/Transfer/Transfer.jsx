import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
class Transfer extends Component {
  state = {};
  columns = [
    { title: "متن درخواست", field: "text"  },
    { title: "تعداد", field: "count" ,type:'number'}
  ];
  render() {
    return (
      <div>
        <Table
          url="api/transfer"
          primaryKey="transferId"
          title="درخواست نقل و انتقال سهام"
          columns={this.columns}
        />
      </div>
    );
  }
}

export default Transfer;
