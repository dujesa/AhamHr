import React from "react";
import { Route, Switch } from "react-router";
import ProfessorDetails from "./ProfessorDetails";

const Professors = () => {
  return (
    <Switch>
      <Route exact path="/professors/:id">
        <ProfessorDetails />
      </Route>
    </Switch>
  );
};

export default Professors;
