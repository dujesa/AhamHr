import React, { useEffect, useState } from "react";

import { useParams } from "react-router";
import { useErrorMessage } from "../../providers/error/hooks";
import { getProfessorById } from "../../services/data";

const ProfessorDetails = () => {
  const [professor, setProfessor] = useState(null);
  const { id } = useParams();
  const [, setErrorMessage] = useErrorMessage();

  useEffect(() => {
    getProfessorById(id)
      .then(setProfessor)
      .catch(() => {
        setErrorMessage("Failed fetching professor.");
      });
  }, []);

  return (
    <div>
      {professor?.firstname}
      {professor?.lastName}
      {professor?.rating}
      {professor?.availableTermins.map((termin) => (
        <p>
          {termin.startTime} - {termin.endTime}
        </p>
      ))}
    </div>
  );
};

export default ProfessorDetails;
