import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
import ApiTable from "../../Widgets/Table/ApiTable";
class Test extends Component {
  state = {};
  render() {
    const columns = [
      { title: "نام بانک", field: "bankName" },

    ];
    return (
      <div>
        <Table grouping selection url='api/stockkk' columns = {columns} title='بانک  ها'/> 

      </div>
    );
  }
}

export default Test;
