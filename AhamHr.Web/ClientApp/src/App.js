import React, { useEffect } from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
//import { Provider } from "react-redux";
//import store from "./redux";

import Layout from "./components/Layout";
import RegistrationForm from "./components/Authentication/RegistrationForm";
import Subjects from "./components/Subjects/Subjects";
import LoginForm from "./components/Authentication/LoginForm";

const App = () => {
  

  return (
    <div>
      <Layout>
        <LoginForm />
      </Layout>
    </div>
    /*<ErrorProvider>
      <BrowserRouter>
        <Switch>
          <Route path="/subjects">
              <Subjects />
          </Route>
          <Route path="/subjects">
            <ProfessorProvider>
              <Professors />
            </ProfessorProvider>
          </Route>
          <Route path="/404">
            <NotFound />
          </Route>
          <Redirect to="/404" />
        </Switch>
        <Error />
      </BrowserRouter>
    </ErrorProvider>*/
  );
};

export default App;
