import React, { Component } from "react";
import UserCreate from "./UserCreate";
import {
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  Button,
  Grid
} from "@material-ui/core";
import UserEdit from "./UserEdit";
import Api from "../../../Api";

class User extends Component {
  state = { users: [] };
  render() {
    return (
      <div>
        <UserCreate
          update={c => {
            this.state.users.push(c);
            this.setState({...this.state.users});
          }}
        />
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>نام کاربری</TableCell>
              <TableCell>نام و نام خانوادگی</TableCell>
              <TableCell>کد ملی </TableCell>
              <TableCell>عملیات </TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {this.state.users.map(c => (
              <TableRow>
                <TableCell>{c.username}</TableCell>
                <TableCell>{c.name + " " + c.lastName}</TableCell>
                <TableCell>{c.nationalCode}</TableCell>
                <TableCell>{c.mobile}</TableCell>
                <TableCell>
                  <Grid container spacing={2}>
                    <Grid item>
                      <UserEdit
                        update={c => {
                          this.update(c);
                        }}
                        id={c.userId}
                      />
                    </Grid>
                    <Grid item>
                      <Button
                        onClick={() => {
                          if (window.confirm("آیا مایل به حذف می باشید؟؟؟")) {
                            this.Delete(c.userId);
                          }
                        }}
                        color="primary"
                        variant="outlined"
                      >
                        حذف
                      </Button>
                    </Grid>
                  </Grid>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    );
  }
  update = c => {
    const oldDate = this.state.users.filter(w => w.userId == c.userId)[0];
    const index = this.state.users.indexOf(oldDate);
    this.state.users[index] = c;
    this.setState({ ...this.state.users });
  };
  componentDidMount() {
 new Api().get("api/user")
      .then(c => c.json())
      .then(c => this.setState({ users: c }));
  }

  Delete = id => {
   new Api().delete("api/user/" + id, {
      method: "delete"
    })
      .then(c => c.json())
      .then(c => {
        const oldDate = this.state.users.filter(w => w.userId == c)[0];
        const index = this.state.users.indexOf(oldDate);
        this.state.users.splice(index);
        this.setState({ ...this.state.users });
      });
  };
}

export default User;
