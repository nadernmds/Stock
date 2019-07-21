import React, { Component } from "react";
import ComboBox from "../ComboBox/ComboBox";

class ComboBoxCompany extends Component {
  state = { items: [] };
  render() {
    return (
      <ComboBox
        value={this.props.value}
        items={this.state.items}
        name={this.props.name}
        onChange={this.props.onChange}
        label="شرکت"
      />
    );
  }

  componentDidMount() {
    fetch("api/company")
      .then(c => c.json())
      .then(c =>
        c.map(w => {
          return { value: w.companyId, text: w.companyName };
        })
      )
      .then(c => this.setState({ items: c }));
  }
}

export default ComboBoxCompany;
