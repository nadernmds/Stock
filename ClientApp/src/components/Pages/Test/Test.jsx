import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
class Test extends Component {
  state = {};
  render() {
    const columns = [
      { title: "نام شرکت", field: "companyName" },
      { title: "تعداد", field: "count" },
      { title: "متن", field: "pep" }
    ];
    return (
      <div>
        <Table
          grouping
          title="شرکت ها"
          url="api/company/"
          columns={columns}
        />
      </div>
    );
  }
}

export default Test;
