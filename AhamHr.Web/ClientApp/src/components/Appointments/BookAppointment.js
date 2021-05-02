import React, { useState } from "react";
import { Link, Redirect, useHistory } from "react-router-dom";
import { useEffect } from "react/cjs/react.development";
import { useErrorMessage } from "../../providers/error/hooks";

import { bookAppointment } from "../../services/data";
import { constructAppointment } from "../../utils/defaults";
import { validateAppointment } from "../../utils/validation";

const BookAppointment = ({professorId, startTime, endTime}) => {
  const [appointment, setAppointment] = useState(constructAppointment());
  const [, setErrorMessage] = useErrorMessage();
  const history = useHistory();

  useEffect(() => {
    
    console.log(history.location.state.professorId);
  }, []);

  const handleInputChange = ({ target: { name, value } }) => {
    setAppointment((prevAppoinment) => ({
      ...prevAppoinment,
      [name]: value,
    }));
  };

  const handleRegistration = async () => {
    if (!validateAppointment(appointment)) {
      return;
    }

    bookAppointment(appointment)
      .then(() => {
        return <Redirect to="/students/profile" />;
      })
      .catch(setErrorMessage("Error while booking appoinemnt!"));
  };

  return (
    <div>
      <h1>Pojedinosti</h1>
      <form>
        <label>Vrijeme</label>
        <input
          type="text"
          name="startTime"
          value={appointment.startTime}
          placeholder={startTime}
          onChange={handleInputChange}
        />
        <input
          type="text"
          name="endTime"
          value={appointment.endTime}
          placeholder={endTime}
          onChange={handleInputChange}
        />
        <label htmlFor="comment">Komentar</label>
        <input
          type="text"
          name="comment"
          value={appointment.comment}
          onChange={handleInputChange}
        />
        <label htmlFor="literature">Komentar</label>
        <input
          type="text"
          name="literature"
          value={appointment.literature}
          onChange={handleInputChange}
        />
      </form>
      <button onClick={handleRegistration}>Registriraj se</button>
      <p>
        Nemaš račun?<Link to="/auth/login">Prijavi se.</Link>
      </p>
    </div>
  );
};

export default BookAppointment;
