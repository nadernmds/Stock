import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
class InstallmentTemplate extends Component {
  state = {};
  columns = [
    { field: "title", title: "عنوان اقساط" },
    { field: "fromDate", title: "از تاریخ", date: true },
    { field: "toDate", title: "تا تاریخ", date: true },
    { field: "count", title: "تعداد کل اقساط" },
    { field: "payday", title: "روز پرداخت در هر ماه" },
    { field: "amount", title: "مقدار پرداختی" }
  ];

  render() {
    return (
      <Table
        title="قسط بندی"
        primaryKey="instalmentTemplateId"
        columns={this.columns}
        url="api/instalmentTemplate"
      />
    );
  }
}

export default InstallmentTemplate;
