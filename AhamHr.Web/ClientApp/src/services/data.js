import axios from "axios";
import { isStatusOk } from "../utils/validation";
import { get, post } from "./jwtHandler";

export const registerUser = async (user) => {
  const response = await post("/api/Student/RegisterStudent", user);

  if (!isStatusOk(response)) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }

  return response.data;
};

export const loginUser = async (user) => {
  const response = await post("/api/Account/Login", user);

  if (!isStatusOk(response)) {
    //error provider iskoristi!
    alert(response.data);
    return "";
  }

  return response.data;
};
