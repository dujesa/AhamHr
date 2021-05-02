import React from "react";
import { Route, Switch } from "react-router";
import BookAppointment from "./BookAppointment";

const Appointments = () => {
  return (
    <Switch>
      <Route exact path="/appointments/book">
        <BookAppointment />
      </Route>
    </Switch>
  );
};

export default Appointments;
