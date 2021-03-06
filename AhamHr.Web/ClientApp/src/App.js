import React, { useEffect } from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
//import { Provider } from "react-redux";
//import store from "./redux";

import Landing from "./components/Landing";
import NotFound from "./components/NotFound";
import Authentication from "./components/Authentication";
import ErrorProvider from "./providers/error";
import Error from "./components/Error";
import Professors from "./components/Professors";
import Students from "./components/Students";
import CurrentUserProvider from "./providers/currentUser";

const App = () => {
  return (
    <ErrorProvider>
      <BrowserRouter>
        <Switch>
          <Route exact path="/">
            <Landing />
          </Route>
          <Route path="/auth">
            <Authentication />
          </Route>
          <CurrentUserProvider>
            <Route path="/professors">
              <Professors />
            </Route>
            <Route path="/students">
              <Students />
            </Route>
          </CurrentUserProvider>
          <Route to="/404">
            <NotFound />
          </Route>
          <Redirect to="/404" />
        </Switch>
        <Error />
      </BrowserRouter>
    </ErrorProvider>
  );
};

export default App;
