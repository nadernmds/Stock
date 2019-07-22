import React, { Component } from "react";
import Table from "../../Widgets/Table/Table";
import ApiTable from "../../Widgets/Table/ApiTable";
import ComboBoxCity from "../../Widgets/ComboBoxes/ComboBoxCity";
import HorizontalLinearStepper from "../../Widgets/Stepper/Stepper";
class Test extends Component {
  state = {company:''   };
  onChange=(e)=>{
    this.setState({[e.target.name]:e.target.value})
  }
  render() {
    return (
      <div>
        <HorizontalLinearStepper/>
      </div>
    );
  }
}

export default Test;
