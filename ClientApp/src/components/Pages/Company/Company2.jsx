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
class Company extends Component {
  state = { companys: []};
  render() {
    return (
      <div>

          <Grid container direction="column" xs={4}>
            <form onSubmit={this.onSubmit}>
              <TextField
                value={this.state.companyName}
                onChange={this.onChange}
                id="companyName"
                name="companyName"
                label="نام شرکت"
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
                <TableCell>گروه کاربری</TableCell>
                <TableCell> </TableCell>

              </TableRow>
            </TableHead>
            <TableBody>
              {this.state.companys.map(c => (
                <TableRow>
                  <TableCell>{c.companyName}</TableCell>
                  <TableCell>
                    <a
                      onClick={() => {
                        this.Delete(c.companyId);
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
    fetch("api/Company")
      .then(c => c.json())
      .then(c => this.setState({ companys: c })).then(c=>{console.log(this.state.companys)});
  };
  componentDidMount() {
    this.getAll();
  }
  Delete = id => {
    fetch("api/Company/" + id, {
      method: "delete"
    })
      .then(c => c.json)
      .then(c => {
        this.getAll();
      });
  };

  onSubmit = e => {
    e.preventDefault();
    const formData = { companyName: this.state.companyName };

    // for (const data in this.refs) {
    //   // formData[data] = this.refs[data].value;
    //   this.state[data] = this.refs[data].value;
    // }

    fetch("/api/Company", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    })
      .then(c => c.json())
      .then(c => {
        this.setState({ companys: [...this.state.companys, c], companyName: "" });
      });
  };
}

export default Company;
