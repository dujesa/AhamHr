import React from "react";
import { Redirect, Route, Switch } from "react-router";
import { getJwtToken } from "../../services/jwtHandler";
import StudentProfile from "./StudentProfile";

const Students = () => {
  if (!getJwtToken()) {
    return <Redirect to="/404" />
  }

  return (
    <Switch>
      <Route exact path="/students/profile">
        <StudentProfile />
      </Route>
    </Switch>
  );
};

export default Students;
