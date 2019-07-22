import { create } from "jss";
import rtl from "jss-rtl";
import { createMuiTheme } from "@material-ui/core/styles";

import { StylesProvider, jssPreset, ThemeProvider } from "@material-ui/styles";
import React, { Component } from "react";
import { indigo, pink, red, green } from "@material-ui/core/colors";
// Configure JSS
const jss = create({ plugins: [...jssPreset().plugins, rtl()] });

class RTL extends Component {
  constructor(props) {
    super(props);
  }

  theme = () => {
    return createMuiTheme({
      direction: "rtl",
      palette: {
        primary: green,
        secondary: pink,
        error: red,
        // Used by `getContrastText()` to maximize the contrast between the background and
        // the text.
        contrastThreshold:1,
        // Used to shift a color's luminance by approximately
        // two indexes within its tonal palette.
        // E.g., shift from Red 500 to Red 300 or Red 700.
        tonalOffset: 0.2
      }
    });
  };

  render() {
    return (
      <StylesProvider jss={jss}>
        <ThemeProvider theme={this.theme()}>
          {this.props.children}
        </ThemeProvider>
      </StylesProvider>
    );
  }
}

export default RTL;