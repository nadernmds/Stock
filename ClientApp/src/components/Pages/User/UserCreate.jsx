import React, { Component } from "react";
import {
  Grid,
  TextField,
  Container,
  Button,
  FormControl,
  Select,
  MenuItem,
  InputLabel,
  FormHelperText,
  Input
} from "@material-ui/core";
import FullDialog from "../../Widgets/FullDialog/FullDialog";
import ComboBoxBank from "../../Widgets/ComboBoxes/BankCombox";
import ComboBoxCompany from "../../Widgets/ComboBoxes/ComboBoxCompany";
import ComboBoxUserGroup from "../../Widgets/ComboBoxes/ComboBoxUserGroup";
import ComboBoxCity from "../../Widgets/ComboBoxes/ComboBoxCity";
import Item from "../../Widgets/Item/Item";
import Api from "../../../Api";

class UserCreate extends Component {
  state = { companyId: "", bankId: "" };

  onChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };
  onSubmit = e => {
    e.preventDefault();
    const formData = { ...this.state };
   new Api().post("/api/user", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    })
      .then(c => c.json())
      .then(c => {
        // for (const key in this.state) {
        //   if (this.state.hasOwnProperty(key)) {
        //     this.state[key] = "";
        //   }
        // }
        // this.setState({ ...formData });
        this.props.update({ ...c });
      });
  };
  onChangeDate=e=>{
    this.setState({ [e.target.name]:new Api().toMiladiDate( e.target.value) });
  }
  render() {
    return (
      <div>
        <form autoComplete="Off">
          <FullDialog
            value={this.props.value}
            update={this.props.update}
            buttonText="جدید"
            OnSave={e => {
              this.onSubmit(e);
            }}
          >
            <br />
            <br />
            <Container>
              <Grid container>
                <Item>
                  <TextField
                    name="username"
                    label="نام کاربری"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    type="password"
                    name="password"
                    label="کلمه عبور"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    type="mail"
                    name="mail"
                    label="ایمیل"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField name="name" label="نام" onChange={this.onChange} />
                </Item>
                <Item>
                  <TextField
                    name="lastName"
                    label="نام خانوادگی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="fatherName"
                    label="نام پدر"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <ComboBoxBank
                    value={this.state.bankId}
                    onChange={this.onChange}
                    name="bankId"
                  />
                </Item>
                <Item>
                  <ComboBoxCompany
                    value={this.state.companyId}
                    onChange={this.onChange}
                    name="companyId"
                  />
                </Item>
                <Item>
                  <ComboBoxUserGroup
                    value={this.state.userGroupId}
                    onChange={this.onChange}
                    name="userGroupId"
                  />
                </Item>
                <Item>
                  <TextField
                    name="personnelCode"
                    label="کدپرسنلی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="mobile"
                    label="شماره موبایل"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="phone"
                    label="شماره های تماس"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="address"
                    label="نشانی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="postalCode"
                    label="کد پستی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="birthDate"
                    label="تاریخ تولد"
                    onChange={this.onChangeDate}
                  />
                </Item>
                <Item>
                  <TextField
                    name="birthPlace"
                    label="محل تولد"
                    onChange={this.onChange}
                  />
                </Item>
                <ComboBoxCity
                  onChange={this.onChange}
                  value={this.state.cityId}
                  name="cityId"
                />
                <Item>
                  <TextField
                    name="representor"
                    label="نام نماینده"
                    onChange={this.onChange}
                  />
                </Item>

                <Item>
                  <TextField
                    name="nationalCode"
                    label="کد ملی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="shenasNameCode"
                    label="شماره شناسنامه"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="bankAccount"
                    label="شماره حساب بانکی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="shebaCode"
                    label="شماره شبا"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="bankBranch"
                    label="شعبه"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="bankBranchCode"
                    label="کد شعبه بانک"
                    onChange={this.onChange}
                  />
                </Item>
              </Grid>
            </Container>
          </FullDialog>
        </form>
      </div>
    );
  }
}

export default UserCreate;
