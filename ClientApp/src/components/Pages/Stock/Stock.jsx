import React, { Component } from "react";
import ApiTable from "../../Widgets/Table/ApiTable";
import Table from "../../Widgets/Table/Table";
class Stock extends Component {
  state = {
    columns: [
      { title: "عنوان", field: "title" },
      { title: "قیمت واحد", field: "pricePerUnit" },
      { title: "تعداد", field: "count" }
    ]
  };
  render() {
    return (
      <div>
        <Table
          title="سهام "
          columns={this.state.columns}
          url="api/Stock/"
          primaryKey="stockId"
        />
      </div>
    );
  }
}

export default Stock;
