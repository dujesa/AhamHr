import React, { useEffect } from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
//import { Provider } from "react-redux";
//import store from "./redux";

import Landing from "./components/Landing";
import NotFound from "./components/NotFound";
import Authentication from "./components/Authentication";

const App = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/">
          <Landing />
        </Route>
        <Route path="/auth">
          <Authentication />
        </Route>
        <Route to="/404">
          <NotFound />
        </Route>
        <Redirect to="/404" />
      </Switch>
    </BrowserRouter>
  );
};

export default App;
