import React, { Component } from "react";
import {
  Button,
  Grid,
  TextField,
  Box,
  Container,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody
} from "@material-ui/core";
class Bank extends Component {
  state = { banks: []};
  render() {
    return (
      <div>

          <Grid container direction="column" xs={4}>
            <form onSubmit={this.onSubmit}>
              <TextField
                value={this.state.bankName}
                onChange={this.onChange}
                id="bankName"
                name="bankName"
                label="نام بانک"
                margin="normal"
              />
              {/* <Button type="submit" variant="outlined">
                ذخیره
              </Button> */}
            </form>
          </Grid>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>نام بانک</TableCell>
                <TableCell> </TableCell>

              </TableRow>
            </TableHead>
            <TableBody>
              {this.state.banks.map(c => (
                <TableRow>
                  <TableCell>{c.bankName}</TableCell>
                  <TableCell>
                    <a
                      onClick={() => {
                        this.Delete(c.bankId);
                      }}
                      href="#!"
                    >
                      حذف
                    </a>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>

      </div>
    );
  }
  onChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };

  getAll = () => {
    fetch("api/bank")
      .then(c => c.json())
      .then(c => this.setState({ banks: c }));
  };
  componentDidMount() {
    this.getAll();
  }
  Delete = id => {
    fetch("api/bank/" + id, {
      method: "delete"
    })
      .then(c => c.json)
      .then(c => {
        this.getAll();
      });
  };

  onSubmit = e => {
    e.preventDefault();
    const formData = { bankName: this.state.bankName };

    // for (const data in this.refs) {
    //   // formData[data] = this.refs[data].value;
    //   this.state[data] = this.refs[data].value;
    // }

    fetch("/api/bank", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    })
      .then(c => c.json())
      .then(c => {
        this.setState({ banks: [...this.state.banks, c], bankName: "" });
      });
  };
}

export default Bank;
