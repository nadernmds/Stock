import React, { Component, Fragment } from "react";
import FullDialog from "../../Widgets/FullDialog/FullDialog";
import {
  Container,
  Button,
  Paper,
  Table,
  TableRow,
  TableHead,
  TableBody,
  TableCell
} from "@material-ui/core";
import Api from "../../../Api";
import MaterialTable from "material-table";
class ManageInstalment extends Component {
  state = {
    items: [],
    instalments: []
  };
  columns = [
    { title: "عنوان", field: "title" },
    { title: "میزان مبلغ", field: "amount" },
    { title: "شماره فیش", field: "billcode" }
  ];
  render() {
    return (
      <div>
        <FullDialog buttonText="  مدیریت اقساط">
          <Container>
            <br />
            <br />
            <Paper style={{ padding: 20 }}>
              <div style={{ padding: 20 }}> تعریف اقساط</div>
              {this.state.items.map(c => (
                <Button color="primary" variant="contained">
                  {c.title}
                </Button>
              ))}
            </Paper>

            <Table>
              <TableHead>
                <TableRow>
                  <TableCell>عنوان</TableCell>
                  <TableCell>تاریخ</TableCell>
                  <TableCell>مقدار</TableCell>
                  <TableCell>شماره فیش پرداختی</TableCell>
                  <TableCell>نوع پرداخت</TableCell>
                </TableRow>
              </TableHead>
              <TableBody>
                {this.state.instalments.map(c => (
                  <TableRow>
                    <TableCell>{c.title}</TableCell>
                    <TableCell>{c.date}</TableCell>
                    <TableCell>{c.amount}</TableCell>
                    <TableCell>{c.billCode}</TableCell>
                    <TableCell>{c.title}</TableCell>{" "}
                  </TableRow>
                ))}
              </TableBody>
            </Table>
          </Container>
        </FullDialog>
      </div>
    );
  }
  componentDidMount() {
    new Api()
      .get("api/instalmentTemplate")
      .then(c => c.json())
      .then(c => this.setState({ items: c }));
    new Api()
      .get("api/payment/", this.props.id)
      .then(c => c.json())
      .then(c => this.setState({ instalments: c }));
  }
}

export default ManageInstalment;
