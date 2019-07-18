import React, { Component } from "react";
import ApiTable from "../../Widgets/Table/ApiTable";
class Stock extends Component {

  state = {
    columns: [
      { title: "قیمت واحد", field: "pricePerUnit" },
      { title: "تعداد", field: "count" },
    ]
  };
  render() {

    return (
      <div>
        <ApiTable
          title="سهام "
          columns={this.state.columns}
          url="api/Stock/"
        />
      </div>
    );
  }
}

export default Stock;
