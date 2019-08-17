import React, { Component } from "react";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import CssBaseline from "@material-ui/core/CssBaseline";
import TextField from "@material-ui/core/TextField";
import LockOutlinedIcon from "@material-ui/icons/LockOutlined";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import Container from "@material-ui/core/Container";
import AuthService from "../../../AuthService";

const useStyles = makeStyles(theme => ({
  "@global": {
    body: {
      backgroundColor: theme.palette.common.white
    }
  },
  paper: {
    marginTop: theme.spacing(8),
    display: "flex",
    flexDirection: "column",
    alignItems: "center"
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main
  },
  form: {
    width: "100%", // Fix IE 11 issue.
    marginTop: theme.spacing(1)
  },
  submit: {
    margin: theme.spacing(3, 0, 2)
  }
}));

class Login extends Component {
  state = {};
  render() {
    const classes = useStyles;
    console.log(this.state);
    return (
      <Container component="main" maxWidth="xs">
        <br /> <br />
        <br />
        <br />
        <br />
        <CssBaseline />
        <div className={classes.paper}>
          <Avatar style={{ margin: "auto" }} className={classes.avatar}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography align="center" component="h1" variant="h5">
            ورود به سامانه
          </Typography>
          <form onSubmit={this.onSubmit} className={classes.form} noValidate>
            <TextField
              variant="outlined"
              margin="normal"
              required
              fullWidth
              onChange={this.onChange}
              id="username"
              label="نام کاربری"
              name="username"
              autoComplete="username"
              autoFocus
            />
            <TextField
              variant="outlined"
              margin="normal"
              required
              onChange={this.onChange}
              fullWidth
              name="password"
              label="کلمه عبور"
              type="password"
              id="password"
              autoComplete="current-password"
            />
            {/* 
            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label="مرابه خاطر بسپار"/>
             */}
            <Button
              type="submit"
              fullWidth
              variant="contained"
              color="primary"
              className={classes.submit}
            >
              ورود
            </Button>
            {/* <Grid container>
              <Grid item xs>
                <Link href="#" variant="body2">
                  کلمه عبورم را فراموش کرده ام
                </Link>
              </Grid>
              <Grid item>
                <Link href="#" variant="body2">
                  {"ثبت نام"}
                </Link>
              </Grid>
            </Grid> */}
          </form>
        </div>
      </Container>
    );
  }
  onSubmit = e => {
    e.preventDefault();
    new AuthService()
      .login(this.state.username, this.state.password)
      .then(() => {
        this.props.history.replace("/");
      })
      .catch(() => {
        alert("ورود موفقیت آمیز نبود");
      });
  };
  componentWillMount() {
    if (new AuthService().loggedIn()) {
      this.props.history.replace("/");
    }
  }

  onChange = e => {
    this.setState({
      [e.target.name]: e.target.value
    });
  };
}

export default Login;

// export default function Login() {
//   const classes = useStyles();

//   return (

//   );

// }
