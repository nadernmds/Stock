import React, { Component } from "react";
import { Paper, Typography } from "@material-ui/core";
import Api from "../../../Api";
class Summary extends Component {
  state = {};

  render() {
    console.log(this.state);
    return (
      <Paper style={{ padding: 25 }}>
        <Typography variant="caption">
          جمع بدهکاری: {this.state.dept} ریال{" "}
        </Typography>
        <br />
        <Typography variant="caption">
          جمع بستانکاری: {this.state.credit} ریال{" "}
        </Typography>
        <br />
        <Typography variant="caption">
          جمع بدهکاری و بستانکاری تا به امروز : {this.state.sum} ریال
        </Typography>
        <br />
        <Typography variant="caption">
          جمع موثر تا به امروز : {this.state.fullSum} ریال
        </Typography>
      </Paper>
    );
  }
  componentDidMount() {
    new Api()
      .post("api/payment/getSummary/" + this.props.id)
      .then(c => c.json())
      .then(c => this.setState({ ...c }));
  }
}

export default Summary;
