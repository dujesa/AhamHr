import React, { useEffect, useState } from "react";

import { Redirect, useHistory, useParams } from "react-router";
import { useErrorMessage } from "../../providers/error/hooks";
import { getProfessorById } from "../../services/data";

const ProfessorDetails = () => {
  const [professor, setProfessor] = useState(null);
  const { id } = useParams();
  const [, setErrorMessage] = useErrorMessage();
  const history = useHistory();

  useEffect(() => {
    getProfessorById(id)
      .then(setProfessor)
      .catch(() => {
        setErrorMessage("Failed fetching professor.");
      });
  }, []);

  const handleBookingTermin = (startTime, endTime) => {
    history.push({
      pathname: "/appointments/book",
      state: {
        professorId: professor.id,
        startTime: startTime,
        endTime: endTime,
      },
    });
  };

  return (
    <div>
      {professor?.firstname}
      {professor?.lastName}
      {professor?.rating}
      {professor?.availableTermins.map((termin) => (
        <div key={termin.id}>
          <p>
            {termin.startTime} - {termin.endTime}
          </p>
          <button
            onClick={() =>
              handleBookingTermin(termin.startTime, termin.endTime)
            }
          >
            zakaži termin
          </button>
        </div>
      ))}
    </div>
  );
};

export default ProfessorDetails;
