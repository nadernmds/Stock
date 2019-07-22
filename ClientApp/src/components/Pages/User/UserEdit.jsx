import React, { Component } from "react";
import { Grid, TextField, Container } from "@material-ui/core";
import FullDialog from "../../Widgets/FullDialog/FullDialog";
import ComboBoxBank from "../../Widgets/ComboBoxes/BankCombox";
import ComboBoxCompany from "../../Widgets/ComboBoxes/ComboBoxCompany";
import ComboBoxUserGroup from "../../Widgets/ComboBoxes/ComboBoxUserGroup";
import ComboBoxCity from "../../Widgets/ComboBoxes/ComboBoxCity";
import Item from "../../Widgets/Item/Item";

class UserEdit extends Component {
  state = { companyId: "", bankId: "" };

  onChange = e => {
    this.setState({ [e.target.name]: e.target.value });
  };
  onSubmit = e => {
    e.preventDefault();
    const formData = { ...this.state };
    fetch("/api/user/" + this.props.id, {
      method: "Put",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    }).then(c => {
      if (c.ok) {
        // for (const key in this.state) {
        //   if (this.state.hasOwnProperty(key)) {
        //     this.state[key] = "";
        //   }
        // }
        this.props.update({ ...formData });
      }
    });
  };
  componentDidMount() {
    fetch("api/user/" + this.props.id)
      .then(c => c.json())
      .then(c => this.setState({ ...c }));
  }

  render() {
    return (
      <div>
        <form autoComplete="Off">
          <FullDialog
            value={this.props.value}
            update={this.props.update}
            buttonText="ویرایش"
            OnSave={e => {
              this.onSubmit(e);
            }}
          >
            <br />
            <br />
            <Container>
              <Grid container>
                <input type="hidden" name="id" value={this.props.id} />
                <Item>
                  <TextField
                    value={this.state.username}
                    name="username"
                    label="نام کاربری"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.password}
                    type="password"
                    name="password"
                    label="کلمه عبور"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.mail}
                    type="mail"
                    name="mail"
                    label="ایمیل"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    name="name"
                    label="نام"
                    value={this.state.name}
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.lastName}
                    name="lastName"
                    label="نام خانوادگی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.fatherName}
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
                    value={this.state.personnelCode}
                    name="personnelCode"
                    label="کد پرسنلی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.mobile}
                    name="mobile"
                    label="شماره موبایل"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.phone}
                    name="phone"
                    label="شماره های تماس"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.address}
                    name="address"
                    label="نشانی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.postalCode}
                    name="postalCode"
                    label="کد پستی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.birthDate}
                    name="birthDate"
                    label="تاریخ تولد"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.birthPlace}
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
                    value={this.state.representor}
                    name="representor"
                    label="نام نماینده"
                    onChange={this.onChange}
                  />
                </Item>

                <Item>
                  <TextField
                    value={this.state.nationalCode}
                    name="nationalCode"
                    label="کد ملی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.shenasNameCode}
                    name="shenasNameCode"
                    label="شماره شناسنامه"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.bankAccount}
                    name="bankAccount"
                    label="شماره حساب بانکی"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.shebaCode}
                    name="shebaCode"
                    label="شماره شبا"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.bankBranch}
                    name="bankBranch"
                    label="شعبه"
                    onChange={this.onChange}
                  />
                </Item>
                <Item>
                  <TextField
                    value={this.state.bankBranchCode}
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

export default UserEdit;
