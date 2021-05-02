import React, { useState } from "react";
import { Redirect } from "react-router";
import { useEffect } from "react/cjs/react.development";
import { useCurrentUser } from "../../providers/currentUser/hooks";
import { useErrorMessage } from "../../providers/error/hooks";
import { getStudentProfileData } from "../../services/data";
import { getJwtToken } from "../../services/jwtHandler";

const StudentProfile = () => {
  const [currentUser, setCurrentUser] = useCurrentUser();
  const [, setErrorMessage] = useErrorMessage();

  useEffect(() => {
    if (!!getJwtToken() && !currentUser) {
      getStudentProfileData()
        .then(setCurrentUser)
        .catch(() => {
          setErrorMessage("Failed fetching users profile data.");
        });
    }

    if (!currentUser) {
      return <Redirect to="/auth/login" />;
    }
  }, []);

  return (
    <div>
      <img />
      <h2>
        {currentUser?.firstName}
        {currentUser?.lastName}
      </h2>
      <p>{currentUser?.email}</p>
      {currentUser?.appointments.map((appointment) => (
        <div key={appointment.id}>
          <h2>{appointment.literature}</h2>
          <p>
            {appointment.startTime}-{appointment.endTime}
          </p>
        </div>
      ))}
    </div>
  );
};

export default StudentProfile;
