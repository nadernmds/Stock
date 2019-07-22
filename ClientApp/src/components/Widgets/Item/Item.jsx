import React, { Component } from "react";
import { Grid, FormControl } from "@material-ui/core";

class Item extends Component {
  state = {};
  render() {
    return (
      <Grid item lg={4} md={6} sm={12}>
        <FormControl style={{minWidth:200}}  >{this.props.children}</FormControl>
      </Grid>
    );
  }
}

export default Item;
