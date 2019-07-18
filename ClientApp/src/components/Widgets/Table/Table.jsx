import React, { Component } from "react";
import { Grid, TextField, Paper, Card, Box, Button } from "@material-ui/core";
import BaseTable from "./BaseTable";
class Table extends Component {
  state = {
    EditMode: false
  };
  names = [];
  render() {
    this.init();
    return (
      <div>
        {!this.state.EditMode ? (
          <Card style={{maxWidth:window.innerWidth, padding: 30 }}>
            <form onSubmit={this.onSubmit}>
              <Grid container>
                {this.names.map(c => (
                  <Grid item md={6}>
                    <Box width={3 / 4}>
                      <TextField                         
                        autoComplete={false}
                        value={this.state[c.name]}
                        onChange={this.onChange}
                        fullWidth
                        label={c.persianName}
                        name={c.name}
                        type={c.type=='number'?'number':(c.type=='password'?'password':'text')}
                      />
                    </Box>
                  </Grid>
                ))}
              </Grid>
              <Button
                style={{ marginTop: 10 }}
                type="submit"
                variant="outlined"
              >
                ذخیره
              </Button>
            </form>
          </Card>
        ) : (
          <div>
            <Card style={{ padding: 30 }}>
              <form
                onSubmit={e => {
                  this.OnEditSubmit(
                    e,
                    this.state.EditData[this.props.primaryKey]
                  );
                }}
              >
                <input
                  type="hidden"
                  name={this.props.primaryKey}
                  value={this.state.EditData[this.props.primaryKey]}
                />
                <Grid container>
                  {this.names.map(c => (
                    <Grid item md={6}>
                      <Box width={3 / 4}>
                        <TextField
                          autoComplete={false}
                          onChange={this.onChange}
                          fullWidth
                          label={c.persianName}
                          name={c.name}
                          value={this.state.EditData[c.name]}
                        />
                      </Box>
                    </Grid>
                  ))}
                </Grid>
                <Button
                  style={{ marginTop: 10 }}
                  type="submit"
                  variant="outlined"
                >
                  ذخیره
                </Button>
              </form>
            </Card>
          </div>
        )}
        <BaseTable
          deleteSome={this.props.deleteSome}
          url={this.props.url}
          onRowClick={(e, data) => {
            this.setState({ EditMode: true, EditData: data });
          }}
          noAdd
          noEdit
          update={c => this.setState({ ...c })}
          data={this.state.data}
          grouping={this.props.grouping}
          selection={this.props.selection}
          onSelectionChange={this.props.onSelectionChange}
          columns={this.props.columns}
          title={this.props.title}
        />
      </div>
    );
  }
  onChange = e => {
    if (this.state.EditMode) {
      this.setState({
        EditData: { ...this.state.EditData, [e.target.name]: e.target.value }
      });
    } else {
      this.setState({ [e.target.name]: e.target.value });
    }
  };
  onSubmit = e => {
    e.preventDefault();
    const formData = {};
    let keys = this.names.map(c => c.name);
    for (let i = 0; i < keys.length; i++) {
      formData[keys[i]] = this.state[keys[i]];
    }
    fetch(this.props.url, {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    })
      .then(c => c.json())
      .then(c => {
        for (const key in formData) {
          if (formData.hasOwnProperty(key)) {
            formData[key] = "";
          }
        }
        this.setState({ data: [...this.state.data, c], ...formData });
      });
  };
  init = () => {
    const columns = this.props.columns;
    this.names = [];
    for (const key in columns) {
      if (columns.hasOwnProperty(key)) {
        const name = columns[key].field;
        const persianName = columns[key].title;
        this.names.push({ name, persianName });
      }
    }
  };
  OnEditSubmit = (e, id) => {
    e.preventDefault();
    const formData = {};
    let keys = this.names.map(c => c.name);
    formData[this.props.primaryKey] = this.state.EditData[
      this.props.primaryKey
    ];

    for (let i = 0; i < keys.length; i++) {
      formData[keys[i]] = this.state.EditData[keys[i]];
    }
    fetch(this.props.url + "/" + id, {
      method: "put",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(formData)
    })
      .then(c => {
        if (c.ok) {
          var prevState = [...this.state.data];
          let oldData = prevState.find(c => c[this.props.primaryKey] == id);
          const newData = { ...oldData, ...formData };
          prevState[prevState.indexOf(oldData)] = newData;
          this.setState({
            ...this.state,
            data: prevState,
            EditData: {},
            EditMode: false
          });
        }
      })
      .catch(c => {
        console.log(c);
      });
  };
  componentDidMount() {
    fetch(this.props.url)
      .then(c => c.json())
      .then(c => this.setState({ data: c }));
  }
}

export default Table;
