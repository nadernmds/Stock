import "bootstrap/dist/css/bootstrap.css";
import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import App from "./App";
import registerServiceWorker from "./registerServiceWorker";
import RTL from "./components/RTL";

const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href");
const rootElement = document.getElementById("root");

ReactDOM.render(
  <RTL>
    <BrowserRouter basename={baseUrl}>
      <App />
    </BrowserRouter>
  </RTL>,
  rootElement
);

registerServiceWorker();
