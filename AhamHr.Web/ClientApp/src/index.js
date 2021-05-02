import React from "react";
import ReactDOM from "react-dom";

import App from "./App";
import configureAxios from "./services/axiosConfiguration";
import "./style.css";

configureAxios();

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById("root")
);
