import React from "react";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogContentText from "@material-ui/core/DialogContentText";
import DialogTitle from "@material-ui/core/DialogTitle";
import { Grid } from "@material-ui/core";

export default function FormDialog(props) {
  const [open, setOpen] = React.useState(false);

  function handleClickOpen() {
    setOpen(true);
  }

  function handleClose() {
    setOpen(false);
  }

  return (
    <div>
      <Button variant="outlined" color="primary" onClick={handleClickOpen}>
        {props.buttonText}
      </Button>
      <Dialog
        open={open}
        onClose={handleClose}
        aria-labelledby="form-dialog-title"
      >
        <DialogTitle id="form-dialog-title">{props.title}</DialogTitle>
        <DialogContent>
          <DialogContentText>{props.text}</DialogContentText>
          {props.children}
        </DialogContent>
        <DialogActions  style={{padding:10}} >
          <Grid container alignItems="flex-start">
            <Button
              onClick={() => {
                props.onSave();
                handleClose();
              }}
              color="primary"
            >
              ذخیره
            </Button>{" "}
            <Button onClick={handleClose} color="primary">
              انصراف
            </Button>
          </Grid>
        </DialogActions>
      </Dialog>
    </div>
  );
}
