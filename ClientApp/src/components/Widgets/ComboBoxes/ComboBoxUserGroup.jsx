import React, { Component } from "react";
import ComboBox from "../ComboBox/ComboBox";

class ComboBoxUserGroup extends Component {
  state = { items: [] };
  render() {
    return (
      <ComboBox
        value={this.props.value}
        items={this.state.items}
        name={this.props.name}
        onChange={this.props.onChange}
        label="گروه کاربری"
      />
    );
  }

  componentDidMount() {
    fetch("api/userGroup")
      .then(c => c.json())
      .then(c =>
        c.map(w => {
          return { value: w.userGroupId, text: w.groupName };
        })
      )
      .then(c => this.setState({ items: c }));
  }
}

export default ComboBoxUserGroup;
