import React, { Component } from "react";
import InboxIcon from "@material-ui/icons/MoveToInbox";
import MailIcon from "@material-ui/icons/Mail";
import { Link } from "react-router-dom";
import {
  List,
  Divider,
  ListItemIcon,
  ListItemText,
  ListItem
} from "@material-ui/core";
class Menu extends Component {
  state = {};
  render() {
    return (
      <div>
        <List>
          <ListItem button component={Link} to="/user">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="کاربران" />
          </ListItem>
          <ListItem button component={Link} to="/usergroup">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="گروه کاربری" />
          </ListItem>
          <ListItem button component={Link} to="/bank">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="بانک ها" />
          </ListItem>
          <Divider />
          <ListItem button component={Link} to="/faq">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="سوالات متداول" />
          </ListItem>
          <ListItem button component={Link} to="/stock">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="تعریف سهام" />
          </ListItem>
          <ListItem button component={Link} to="/company">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="شرکت ها" />
          </ListItem>
          <ListItem button component={Link} to="/transfer">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="درخواست نقل و انتقال" />
          </ListItem>
          <ListItem button component={Link} to="/notification">
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
            <ListItemText primary="اطلاعیه ها" />
          </ListItem>
        </List>
      </div>
    );
  }
}

export default Menu;
