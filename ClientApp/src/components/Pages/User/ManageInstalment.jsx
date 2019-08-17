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
  TableCell,
  Grid,
  Divider,
  Typography,
  TextField
} from "@material-ui/core";
import Api from "../../../Api";
import MaterialTable from "material-table";
import FormDialog from "../../Widgets/FormDialog/FormDialog";
import BillPayment from "./BillPayment";
import Summary from "./Summary";
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
              <Grid container>
                <Grid item md={6}>
                  <div style={{ padding: 20 }}> تعریف اقساط</div>
                  {this.state.items.map(c => (
                    <Button
                      style={{ marginRight: 5 }}
                      onClick={() => {
                        this.onSubcribe(c.instalmentTemplateId);
                      }}
                      color="primary"
                      variant="contained"
                    >
                      {c.title}
                    </Button>
                  ))}
                </Grid>
                <Grid item md={6}>
                  <Summary id={this.props.id} />
                </Grid>
              </Grid>
            </Paper>
            <Grid container>
              <Grid md={6} item>
                <Paper style={{ padding: 20 }}>
                  <Typography align="center">بدهکار</Typography>
                  <br />
                  <br />
                  <Table>
                    <TableHead>
                      <TableRow>
                        <TableCell>عنوان</TableCell>
                        <TableCell>تاریخ</TableCell>
                        <TableCell>مقدار</TableCell>
                        {/* <TableCell>شماره فیش پرداختی</TableCell> */}
                      </TableRow>
                    </TableHead>
                    <TableBody>
                      {this.state.instalments
                        .filter(c => c.paymentTypeId == 1)
                        .map(c => (
                          <TableRow>
                            <TableCell>{c.title}</TableCell>
                            <TableCell>
                              {new Api().toPersainDate(c.date)}
                            </TableCell>
                            <TableCell>{c.amount}</TableCell>
                            {/* <TableCell>{c.billCode}</TableCell> */}
                          </TableRow>
                        ))}
                    </TableBody>
                  </Table>
                </Paper>
              </Grid>
              <Grid md={6} item>
                <Paper style={{ padding: 20 }}>
                  <Typography align="center">بستانکار</Typography>
                  <BillPayment
                    updateleft={c => {
                      this.state.instalments.push(c);
                      this.setState({ ...this.state.instalments });
                    }}
                  />
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
                      {this.state.instalments
                        .filter(c => c.paymentTypeId == 2)
                        .map((c, index) => (
                          <TableRow>
                            <TableCell>{c.title}</TableCell>
                            <TableCell>
                              {c.date != null
                                ? new Api().toPersainDate(c.date)
                                : ""}
                            </TableCell>
                            <TableCell>{c.amount}</TableCell>
                            <TableCell>{c.billCode}</TableCell>
                            <TableCell>
                              <Button
                                disabled={c.verified}
                                onClick={() => {
                                  this.verify(c.paymentId, index);
                                }}
                                variant="outlined"
                              >
                                تایید تغییرات
                              </Button>
                            </TableCell>
                          </TableRow>
                        ))}
                    </TableBody>
                  </Table>
                </Paper>
              </Grid>
            </Grid>
          </Container>
        </FullDialog>
      </div>
    );
  }

  onSubcribe = id => {
    if (
      window.confirm(
        "کلیه اقساط مطابق هر چه که در منوی فرم قسط بندی انتخاب کرده اید محاسبه و بصورت بدهکار به سیستم درج خواهد شد آیا مایل به ادامه هستید؟؟"
      )
    ) {
      new Api()
        .post("api/payment/generatePayment/" + id)
        .then(c => c.json())
        .then(c => {
          new Api()
            .get("api/payment/" + this.props.id)
            .then(c => c.json())
            .then(c => this.setState({ instalments: c }));
        });
    }
  };
  verify = (id, index) => {
    if (window.confirm("آیا مایل به تایید تغییرات می باشید؟؟؟")) {
      new Api()
        .post("api/payment/Verify/" + id)
        .then(c => c.json())
        .then(c => {
          if (c) {
            new Api()
              .get("api/payment/" + this.props.id)
              .then(c => c.json())
              .then(c => this.setState({ instalments: c }));
          }
        });
    }
  };
  componentDidMount() {
    new Api()
      .get("api/instalmentTemplate")
      .then(c => c.json())
      .then(c => this.setState({ items: c }));
    new Api()
      .get("api/payment/" + this.props.id)
      .then(c => c.json())
      .then(c => this.setState({ instalments: c }));
  }
}

export default ManageInstalment;
