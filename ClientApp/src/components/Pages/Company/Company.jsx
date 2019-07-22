import React, { Component } from "react";
import Table from "../../Widgets/Table/ApiTable";
import { Table as pep } from "@material-ui/core";
class Company extends Component {
  state = {
    columns: [{ title: "نام شرکت", field: "companyName" }],
    loading: true
  };
  render() {
    return (
      <div>

          <Table
            title="شرکت ها"
            columns={this.state.columns}
            url="api/company/"
          />
      </div>
    );
  }
  componentDidMount(){
    this.setState({loading:false})
  }
}

export default Company;
