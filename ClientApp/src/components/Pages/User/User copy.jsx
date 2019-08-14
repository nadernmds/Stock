import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";

class User extends Component {
  state = {};
  columns = [
    { field: "username", title: "نام کاربری" },
    { field: "password", title: "کلمه عبور",type:'password' },
    { field: "name", title: "نام" },
    { field: "lastName", title: "نام خانوادگی" },
    { field: "fatherName", title: "نام پدر" },
    { field: "personnelCode", title: "کد پرسنلی" },
    { field: "mobile", title: "موبایل" },
    { field: "phone", title: "تلفن"  },
    { field: "address", title: "نشانی" },
    { field: "postalCode", title: "کد پستی" },
    { field: "birthDate", title: "تاریخ تولد" },
    { field: "birthPlace", title: "محل تولد" },
    { field: "representor", title: "نام نماینده" },
    { field: "bankBranchCode", title: "شعبه بانک" },
    { field: "nationalCode", title: "کدملی" },
    { field: "shenasNameCode", title: "شماره شناسامه" },
    { field: "bankAccount", title: "شماره حساب بانک" },
    { field: "shebaCode", title: "کد شبا" },
    { field: "bankBranch", title: "کد شعبه" },
    { field: "mail", title: "ایمیل" }
  ];
  render() {
    return (
      <div>
        <Table url="api/user" columns={this.columns} title='کاربران' />
      </div>
    );
  }
}

export default User;
