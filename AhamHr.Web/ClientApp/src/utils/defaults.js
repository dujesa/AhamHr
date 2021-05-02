import { Appointment, User } from "../consts";

export const constructUser = () => {
  return {
    [User.firstName]: "",
    [User.lastName]: "",
    [User.phoneNumber]: "",
    [User.email]: "",
    [User.password]: "",
    [User.repeatedPassword]: "",
    [User.termsAndConditions]: false,
    [User.newsletter]: false,
  };
};

export const constructAppointment = () => {
  return {
    [Appointment.firstName]: "",
    [Appointment.lastName]: "",
    [Appointment.literature]: "",
    [Appointment.comment]: "",
    [Appointment.appointmentType]: "",
    [Appointment.professorId]: "",
  };
};
