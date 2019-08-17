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
class UserGroup extends Component {
  state = { userGroups: []};
  render() {
    return (
      <div>

          <Grid container direction="column" xs={4}>
            <form onSubmit={this.onSubmit}>
              <TextField
                value={this.state.groupName}
                onChange={this.onChange}
                id="groupName"
                name="groupName"
                label="گروه کاربری "
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
              {this.state.userGroups.map(c => (
                <TableRow>
                  <TableCell>{c.groupName}</TableCell>
                  <TableCell>
                    <a
                      onClick={() => {
                        this.Delete(c.userGroupId);
                      }}
                      href="javaScript:"
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
    fetch("api/usergroup")
      .then(c => c.json())
      .then(c => this.setState({ userGroups: c })).then(c=>{console.log(this.state.userGroups)});
  };
  componentDidMount() {
    this.getAll();
  }
  Delete = id => {
    fetch("api/usergroup/" + id, {
      method: "delete"
    })
      .then(c => c.json)
      .then(c => {
        this.getAll();
      });
  };

  onSubmit = e => {
    e.preventDefault();
    const formData = { groupName: this.state.groupName };

    // for (const data in this.refs) {
    //   // formData[data] = this.refs[data].value;
    //   this.state[data] = this.refs[data].value;
    // }

    fetch("/api/usergroup", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    })
      .then(c => c.json())
      .then(c => {
        this.setState({ userGroups: [...this.state.userGroups, c], groupName: "" });
      });
  };
}

export default UserGroup;
