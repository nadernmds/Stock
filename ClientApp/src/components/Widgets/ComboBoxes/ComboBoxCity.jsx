import React, { Component } from "react";
import ComboBox from "../ComboBox/ComboBox";

class ComboBoxBank extends Component {
  state = {  };
  onChange=(e)=>{
      this.setState({ selectedState : e.target.value})
  }
  render() {
    
    return (
        
        <ComboBox
        value={this.props.value}
        items={this.state.cities}
        name={this.props.name}
        onChange={this.onChange}
        label="استان"
      />       

      <ComboBox
        value={this.props.value}
        items={this.state.states.cities}
        name={this.props.name}
        onChange={this.props.onChange}
        label="شهر ها"
      />
    );
  }

  componentDidMount() {
    fetch("api/state")
      .then(c => c.json())
      .then(c =>
        c.map(w => {
          return { value: w.bankId, text: w.bankName };
        })
      )
      .then(c => this.setState({ satates: c }));
  }
}

export default ComboBoxBank;
