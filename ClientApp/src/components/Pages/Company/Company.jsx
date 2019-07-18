import React, { Component } from "react";
import Table from "../../Widgets/Table/ApiTable";
import {Table as pep}  from "@material-ui/core"
class Company extends Component {
   state = { columns: [{ title: "نام شرکت", field: "companyName" }] };
  render() {

    return (
      <div>
        <Table noAdd  title="شرکت ها"  columns={this.state.columns} url='api/company/'  />
      </div>
    );
  }


}

export default Company;


