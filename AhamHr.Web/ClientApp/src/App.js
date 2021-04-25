import React, { useEffect } from "react";
import { BrowserRouter, Switch, Route, Redirect } from "react-router-dom";
//import { Provider } from "react-redux";
//import store from "./redux";

import Subjects from "./components/Subjects";
import { useState } from "react";
import axios from "axios";

const App = () => {
  const [subjects, setSubjects] = useState(null);
  const [selectedSubject, setSelectedSubject] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    axios.get("/api/Subject/GetAllSubjects").then((response) => {
      setSubjects(response.data);
      setIsLoading(false);
    });
  }, []);

  const addNewSubject = () => {
    axios
      .post("/api/Subject/AddSubject", { subjectName: "Test add" })
      .then(() => {
        setIsLoading(false);
        axios.get("/api/Subject/GetAllSubjects").then(setSubjects);
        if (subjects) setIsLoading(false);
      })
      .catch(() => {
        alert("Add unsucessful!");
      });
  };

  const editSubject = () => {
    axios
      .post("/api/Subject/EditSubject", { id: 2, subjectName: "Test edit" })
      .then(() => {
        setIsLoading(true);
        axios.get("/api/Subject/GetAllSubjects").then(setSubjects);
        if (subjects) setIsLoading(false);
      })
      .catch(() => {
        alert("Edit unsucessful!");
      });
  };

  const deleteSubject = () => {
    const id = 3;

    axios
      .delete(`/api/Subject/DeleteSubject/${id}`)
      .then(() => {
        setIsLoading(true);
        axios.get("/api/Subject/GetAllSubjects").then(setSubjects);
        if (subjects) setIsLoading(false);
      })
      .catch(() => {
        alert("Delete unsucessful!");
      });
  };

  const getSubjectById = () => {
    const id = 2;

    axios
      .get("/api/Subject/GetSubjectById", {
        params: {
          id: id,
        },
      })
      .then(setSelectedSubject);
  };

  return (
    <div>
      <h1>Subjects</h1>
      <p>All subjects:</p>
      {isLoading ? (
        <div>Loading</div>
      ) : (
        subjects.map((subject) => <div>{subject.name}</div>)
      )}
      <p>Selected subject:</p>
      {selectedSubject && <h2>{selectedSubject.name}</h2>}
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
