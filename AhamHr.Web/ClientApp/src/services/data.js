import axios from "axios";
import { isStatusOk } from "../utils/validation";
import { post } from "./jwtHandler";

export const registerUser = async (user) => {
  const response = await post("/api/Student/RegisterStudent", user);

  if (!isStatusOk(response)) {
    throw new Error(`HTTP error! status: ${response.status}`);
  }

  return response.data;
};
