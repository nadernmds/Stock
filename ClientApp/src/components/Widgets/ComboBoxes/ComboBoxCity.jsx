import React, { Component } from "react";
import ComboBox from "../ComboBox/ComboBox";
import { Select, InputLabel, MenuItem } from "@material-ui/core";
import Item from "..//Item/Item";

class ComboBoxCity extends Component {
  state = { states: [], cities: [], selectedState: this.props.state };
  onStateChange = e => {
    const s = this.state.states
      .filter(c => c.stateId == e.target.value)
      .map(c => c.cities);
    this.setState({ cities: s[0], selectedState: e.target.value });
  };

  render() {
    return (
      <React.Fragment>
        <Item>
          <InputLabel htmlFor="state">استان</InputLabel>
          <Select
            onChange={this.onStateChange}
            state={this.props.state}
            value={this.state.selectedState}
            inputProps={{
              name: "state",
              id: "state"
            }}
          >
            <MenuItem value={""}>----</MenuItem>
            {this.state.states.map(c => (
              <MenuItem value={c.stateId}>{c.stateName}</MenuItem>
            ))}
          </Select>
        </Item>
        <Item>
          <InputLabel htmlFor={this.props.name}>شهر</InputLabel>
          <Select
            onChange={this.props.onChange}
            value={this.props.value}
            inputProps={{
              name: this.props.name,
              id: this.props.name
            }}
          >
            <MenuItem value={""}>----</MenuItem>
            {this.state.cities.map(c => (
              <MenuItem value={c.cityId}>{c.cityName}</MenuItem>
            ))}
          </Select>
        </Item>
      </React.Fragment>
    );
  }

  componentDidMount() {
    fetch("api/state")
      .then(c => c.json())
      .then(c => this.setState({ states: c }));
  }
}

export default ComboBoxCity;
