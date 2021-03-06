export const validateLength = (string, length) => string.length > length;

export const validateEmail = (email) =>
  /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
    email
  );

export const areEqual = (first, second) => first === second;

export const isStatusOk = (response) => {
  return !!response && response.status === 200;
};

export const validateUserForLogin = ({ email, password }) => {
  if (!validateEmail(email)) {
    alert("Invalid email address!");
    return false;
  }

  if (!validateLength(password, 5)) {
    alert("Password must contain at least 6 characters!");
    return false;
  }
  return true;
};

export const validateUser = ({
  firstName,
  lastName,
  email,
  password,
  repeatedPassword,
}) => {
  if (firstName === "") {
    alert("First name input cannot be empty!");
    return false;
  }

  if (lastName === "") {
    alert("Last name input cannot be empty!");
    return false;
  }

  if (!validateEmail(email)) {
    alert("Invalid email address!");
    return false;
  }

  if (!validateLength(password, 5)) {
    alert("Password must contain at least 6 characters!");
    return false;
  }

  if (!areEqual(password, repeatedPassword)) {
    alert("Password and repeated password do not match!");
    return false;
  }

  return true;
};

export const validateAppointment = ({
  startTime,
  endTime,
  literature,
  comment,
}) => {
  if (startTime === "") {
    alert("Start time input cannot be empty!");
    return false;
  }

  if (endTime === "") {
    alert("End time input cannot be empty!");
    return false;
  }

  if (literature === "") {
    alert("Literature input cannot be empty!");
    return false;
  }

  if (comment === "") {
    alert("Comment input cannot be empty!");
    return false;
  }

  return true;
};
