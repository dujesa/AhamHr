import React from "react";
import { Redirect } from "react-router";
import { useEffect } from "react/cjs/react.development";
import { useCurrentUser } from "../../providers/currentUser/hooks";
import { useErrorMessage } from "../../providers/error/hooks";
import { getStudentProfileData } from "../../services/data";
import { deleteJwtToken, getJwtToken } from "../../services/jwtHandler";

const StudentProfile = () => {
  const [currentUser, setCurrentUser] = useCurrentUser();
  const [, setErrorMessage] = useErrorMessage();

  useEffect(() => {
    console.log(getJwtToken())

    if (getJwtToken() && !currentUser) {
      getStudentProfileData()
        .then((userProfileData) => setCurrentUser(userProfileData))
        .catch(() => {
          //Refresh has bug => refresh();
          //deleteJwtToken();
          setErrorMessage("Failed fetching users profile data.");
        });
    }

    if (!getJwtToken()) {
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
        <div>
          {appointment.startDate}-{appointment.endDate}
        </div>
      ))}
    </div>
  );
};

export default StudentProfile;
