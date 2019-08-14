import React, { Component } from "react";
import { Calendar, DatePicker } from 'react-persian-datepicker';


class Test extends Component {
  state = {company:''   };
  onChange=(e)=>{
    this.setState({[e.target.name]:e.target.value})
  }
  render() {
    return (
      <div>
 <div>
    <div>
      {/* Calendar Component */}
      <Calendar />
    </div>
    
    <div>
      {/* Date Picker Component */}
      <DatePicker />
    </div>
  </div>

      </div>
    );
  }
}

export default Test;
