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
import ManageInstalment from "./ManageInstalment";
import Summary from "./Summary";

class Index extends Component {
  state = { users: [] };
  cols = [
    { title: "نام", field: "name", type: "text", lookup: {} },
    { title: "رمز", field: "pass", type: "password", lookup: {} },
    {
      title: "کتاب",
      field: "bookId",
      type: "select",
      lookup: [
        { value: 1, text: "harry potter" },
        { value: 2, text: "harry chotter" }
      ]
    }
  ];
  data = [
    { name: "nader", pass: "123" },
    { name: "naser", pass: "1235", bookId: 1 },
    { name: "ali", pass: "5236", bookId: 2 }
  ];
  render() {
    return (
      <div>
        <UserCreate
          update={c => {
            this.state.users.push(c);
            this.setState({ ...this.state.users });
          }}
        />

        <Table>
          <TableHead>
            <TableRow>
              <TableCell> {this.cols.map(c => c.title)}</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {this.data.map(c => (
              <TableRow>
                <this.GenerateCell>
                  
                </this.GenerateCell>
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
                      <ManageInstalment id={c.userId} />
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
  GenerateCell = c => {
    for (const key in c) {
      <TableCell>{c[key]}</TableCell>;
    }
  };
  // update = c => {
  //   const oldDate = this.state.users.filter(w => w.userId == c.userId)[0];
  //   const index = this.state.users.indexOf(oldDate);
  //   this.state.users[index] = c;
  //   this.setState({ ...this.state.users });
  // };
  // componentDidMount() {
  //   new Api()
  //     .get("api/user")
  //     .then(c => c.json())
  //     .then(c => this.setState({ users: c }));
  // }

  // Delete = id => {
  //   new Api()
  //     .delete("api/user/" + id, {
  //       method: "delete"
  //     })
  //     .then(c => c.json())
  //     .then(c => {
  //       const oldDate = this.state.users.filter(w => w.userId == c)[0];
  //       const index = this.state.users.indexOf(oldDate);
  //       this.state.users.splice(index);
  //       this.setState({ ...this.state.users });
  //     });
  // };
}

export default Index;
