import React, { Component } from "react";
import { InputLabel, Select, Input, MenuItem } from "@material-ui/core";

class ComboBox extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <InputLabel htmlFor={this.props.name}>{this.props.label}</InputLabel>
        <Select
          onChange={this.props.onChange}
          value={this.props.value}
          inputProps={{
            name: this.props.name,
            id: this.props.name
          }}
        >
          <MenuItem value={""}>----</MenuItem>
          {this.props.items.map(c => (
            <MenuItem value={c.value}>{c.text}</MenuItem>
          ))}
        </Select>
      </React.Fragment>
    );
  }
}

export default ComboBox;
