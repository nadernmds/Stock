import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
import ApiTable from "../../Widgets/Table/ApiTable";
import { Tab } from "@material-ui/core";
class Faq extends Component {
  state = {
    columns: [
      { title: "سوال ", field: "answer" },
      { title: "جواب ", field: "question" }
    ]
  };

  render() {
    return (
      <div>
        <Table
          grouping
          selection
          url="api/faq/"
          columns={this.state.columns}
          title="سوالات متداول"
        />
      </div>
    );
  }
}

export default Faq;
