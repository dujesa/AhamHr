import React, { useContext, useEffect, useState } from "react";
import { Link } from "react-router-dom";

import { useErrorMessage } from "../../providers/error/hooks";
import { getProfessors } from "../../services/data";
import ProfessorInfo from "./ProfessorInfo";

const ProfessorList = () => {
  const [professors, setProfessors] = useState([]);
  const [, setErrorMessage] = useErrorMessage();

  useEffect(() => {
    getProfessors()
      .then(setProfessors)
      .catch(() => {
        setErrorMessage("Failed fetching professors.");
      });
  }, []);

  return (
    <div>
      {!!professors &&
        professors.map((professor) => <ProfessorInfo key={professor.id} professor={professor} />)}
    </div>
  );
};

export default ProfessorList;
