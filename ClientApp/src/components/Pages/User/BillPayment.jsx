import React, { Component } from "react";
import FormDialog from "../../Widgets/FormDialog/FormDialog";
import { TextField, Grid } from "@material-ui/core";
import Item from "../../Widgets/Item/Item";
import Api from "../../../Api";
class BillPayment extends Component {
  state = {};
  render() {
    console.log(this.state);
    return (
      <FormDialog
        title="ثبت فیش"
        onSave={() => {
          this.onSubmit();
        }}
        style={{ marginRight: 15 }}
        buttonText="ثبت فیش پرداختی"
      >
        <form>
          <Grid container>
            <Item>
              <TextField
                type="text"
                name="title"
                label="عنوان"
                onChange={this.onChange}
              />
            </Item>
            <Item>
              <TextField
                type="text"
                name="date"
                label="تاریخ"
                onChange={this.onChangeDate}
              />
            </Item>
            <Item>
              <TextField
                type="text"
                name="amount"
                label="مقدار مبلغ"
                onChange={this.onChange}
              />
            </Item>
            <Item>
              <TextField
                type="text"
                name="billCode"
                label="شماره فیش بانکی"
                onChange={this.onChange}
              />
            </Item>
          </Grid>
          <input
            type="hidden"
            value="2"
            name="PaymentTypeId"
            id="PaymentTypeId"
          />
        </form>
      </FormDialog>
    );
  }
  onChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };
  onChangeDate=e=>{
    this.setState({ [e.target.name]:new Api().toMiladiDate( e.target.value) });
  }
  onSubmit = () => {
    new Api()
      .post("api/payment", {
        body: JSON.stringify(this.state)
      })
      .then(c => c.json()).then(c=> this.props.updateleft(c));
  };
}

export default BillPayment;
