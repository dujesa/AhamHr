import React from "react";
import { Route, Switch } from "react-router";

import LoginForm from "./LoginForm";
import RegistrationForm from "./RegistrationForm";

const Authentication = () => {
  return (
    <Switch>
      <Route path="/auth/login">
        <LoginForm />
      </Route>
      <Route path="/auth/register">
        <RegistrationForm />
      </Route>
    </Switch>
  );
};

export default Authentication;