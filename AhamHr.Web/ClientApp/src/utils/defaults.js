import { User } from "../consts";

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
