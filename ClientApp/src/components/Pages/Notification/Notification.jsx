import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
class Notification extends Component {
  state = {};
  columns = [{ field: "text", title: "متن اطلاعیه" }];
  render() {
    return (
      <div>
        <Table
          url="api/notification"
          title="اطلاعیه ها"
          columns={this.columns}
          primaryKey="notificationId"
        />
      </div>
    );
  }
}

export default Notification;
