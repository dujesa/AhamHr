import React from "react";
import { Link } from "react-router-dom";

const ProfessorInfo = ({ professor: { id, firstName, lastName, rating } }) => {
  return (
    <div>
      <h3>
        {firstName} {lastName}
      </h3>
      <p>{rating}</p>
      <Link to={`/professors/${id}`}>zakaži termin</Link>
    </div>
  );
};

export default ProfessorInfo;
