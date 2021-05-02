import axios from "axios";
import { isStatusOk } from "../utils/validation";
import { get, post } from "./jwtHandler";

export const registerUser = async (user) => {
  const response = await post("/api/Student/RegisterStudent", user);

  if (!isStatusOk(response)) {
    throw new Error();
  }

  return response.data;
};

export const loginUser = async (user) => {
  const response = await post("/api/Account/Login", user);

  if (!isStatusOk(response)) {
    throw new Error();
  }

  return response.data;
};

export const getStudentProfileData = async () => {
  const response = await get("/api/Student/GetProfileData");

  if (!isStatusOk(response)) {
    throw new Error();
  }

  return response.data;
};


export const getProfessors = async (filters) => {
  const response = await get("/api/Professor/GetFilteredProfessors", {
    params: {
      SubjectIds: filters?.subjectIds,
      MinimalRating: filters?.minimalRating,
    },
  });

  if (!isStatusOk(response)) {
    throw new Error();
  }

  return response.data;
};

export const getProfessorById = async (id) => {
  const response = await get("/api/Professor/GetProfessorById", {
    params: {
      id: id,
    },
  });

  if (!isStatusOk(response)) {
    throw new Error();
  }

  return response.data;
};
