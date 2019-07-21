import React, { Component } from "react";
import ComboBox from "../ComboBox/ComboBox";

class ComboBoxBank extends Component {
  state = { items: [] };
  render() {
    return (
      <ComboBox
        value={this.props.value}
        items={this.state.items}
        name={this.props.name}
        onChange={this.props.onChange}
        label="بانک"
      />
    );
  }

  componentDidMount() {
    fetch("api/bank")
      .then(c => c.json())
      .then(c =>
        c.map(w => {
          return { value: w.bankId, text: w.bankName };
        })
      )
      .then(c => this.setState({ items: c }));
  }
}

export default ComboBoxBank;
