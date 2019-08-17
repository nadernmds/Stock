import React, { Component } from "react";
import MaterialTable from "material-table";
import { forwardRef } from "react";

import AddBox from "@material-ui/icons/AddBox";
import ArrowUpward from "@material-ui/icons/ArrowUpward";
import Check from "@material-ui/icons/Check";
import ChevronLeft from "@material-ui/icons/ChevronLeft";
import ChevronRight from "@material-ui/icons/ChevronRight";
import Clear from "@material-ui/icons/Clear";
import DeleteOutline from "@material-ui/icons/DeleteOutline";
import Edit from "@material-ui/icons/Edit";
import FilterList from "@material-ui/icons/FilterList";
import FirstPage from "@material-ui/icons/FirstPage";
import LastPage from "@material-ui/icons/LastPage";
import Remove from "@material-ui/icons/Remove";
import SaveAlt from "@material-ui/icons/SaveAlt";
import Search from "@material-ui/icons/Search";
import ViewColumn from "@material-ui/icons/ViewColumn";
const tableIcons = {
  Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
  Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
  Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
  DetailPanel: forwardRef((props, ref) => (
    <ChevronRight {...props} ref={ref} />
  )),
  Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
  Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
  Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
  FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
  LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
  NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  PreviousPage: forwardRef((props, ref) => (
    <ChevronLeft {...props} ref={ref} />
  )),
  ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
  SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />),
  ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
  ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
};

class BaseTable extends Component {
  constructor(props) {
    super(props);
    this.state = { columns: this.props.columns };
  }
  // deleteSome = [
  //   {
  //     tooltip: "حذف انتخاب شده ها",
  //     icon: "X",
  //     onClick: (evt, data) => {
  //       data.forEach(item => {
  //         this.Delete(item);
  //       });
  //     }
  //   }
  // ];
  render() {
    return (
      <div>
        <div>
          <MaterialTable
            // actions={this.props.deleteSome ? [...this.deleteSome] : []}
            onRowClick={this.props.onRowClick}
            localization={{
              pagination: {
                labelDisplayedRows: "{from}-{to} از {count}",
                labelRowsSelect: "ردیف",
                labelRowsPerPage: "در هر صفحه",
                lastTooltip: "آخرین",
                firstTooltip: "اولین",
                previousTooltip: "قبلی",
                nextTooltip: "بعدی"
              },
              toolbar: {
                nRowsSelected: "{0} ردیف انتخاب شده",
                searchPlaceholder: "جستجو",
                searchTooltip: "جستجو"
              },
              header: {
                actions: "عملیات"
              },
              body: {
                emptyDataSourceMessage: "چیزی برای نمایش وجود ندارد",
                editTooltip: "ویرایش",
                deleteTooltip: "حذف",
                editRow: {
                  deleteText: "آیا مایل به حذف می باشید؟؟",
                  cancelTooltip: "انصراف",
                  saveTooltip: "ذخیره"
                },
                filterRow: {
                  filterTooltip: "فیلتر"
                }
              },
              grouping: {
                placeholder: "برای گروه بندی نام ستون را به اینجا بکشید"
              }
            }}
            icons={tableIcons}
            title={this.props.title}
            columns={this.props.columns}
            options={{
              grouping: this.props.grouping,
              selection: this.props.selection
            }}
            onSelectionChange={this.props.onSelectionChange}
            data={this.props.data}
            editable={{
              onRowAdd: this.props.noAdd
                ? null
                : newData =>
                    new Promise(resolve => {
                      resolve();
                      const data = [...this.props.data];
                      this.Create(newData);
                      data.push(newData);
                      this.props.update({ data: data });
                    }),
              onRowUpdate: this.props.noEdit
                ? null
                : (newData, oldData) =>
                    new Promise(resolve => {
                      resolve();
                      if (this.Edit(newData, oldData)) {
                        const data = [...this.props.data];
                        data[data.indexOf(oldData)] = newData;
                        this.props.update({ ...this.props.data, data });
                      }
                    }),
              onRowDelete: this.props.noDelete
                ? null
                : oldData =>
                    new Promise(resolve => {
                      this.Delete(oldData);
                      resolve();
                    })
            }}
          />
        </div>
      </div>
    );
  }
  componentDidMount() {
    fetch(this.props.url)
      .then(c => c.json())
      .then(c => this.props.update({ data: c }));
  }
  Create(newData) {
    return fetch(this.props.url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newData)
    })
      .then(c => c.json())
      .then(c => {
        return c;
      });
  }

  Edit = (newData, oldData) => {
    return fetch(this.props.url + "/" + oldData[Object.keys(oldData)[0]], {
      method: "PUT",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newData)
    }).then(c => c.ok);
  };
  Delete = oldData => {
    const id = oldData[Object.keys(oldData)[0]];
    fetch(this.props.url + "/" + +id, {
      method: "delete"
    })
      .then(c => c.json())
      .then(c => {
        const data = [...this.props.data];
        data.splice(data.indexOf(oldData), 1);
        this.props.update({ data });
      });
  };
}

export default BaseTable;
