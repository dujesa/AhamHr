import axios from "axios";
import { useHistory } from "react-router-dom";

export const getJwtToken = () => localStorage.getItem("token");

export const getRefreshToken = () => {
  localStorage.getItem("refreshToken");
};

export const saveJwtToken = (token) => {
  localStorage.setItem("token", token);
};

export const deleteJwtToken = () => {
  localStorage.removeItem("token");
};

export const saveRefreshToken = (refreshToken) => {
  localStorage.setItem("refreshToken", refreshToken);
};

export const parseJwt = (token) => {
  if (!token) return null;

  var base64Url = token.split(".")[1];
  var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
  var jsonPayload = decodeURIComponent(
    atob(base64)
      .split("")
      .map(function (c) {
        return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
      })
      .join("")
  );

  return JSON.parse(jsonPayload);
};

export const handleRedirectToLogin = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("refreshToken");
  localStorage.removeItem("userId");

  //const history = useHistory();
  //history.push("/login");
  window.location.replace("/auth/login");

};

export const refresh = () => {
  const jwtToken = getJwtToken();
  axios.defaults.headers.common["Authorization"] = `Bearer ${jwtToken}`;
  axios
    .get(`api/Account/RefreshToken?token=${jwtToken}`)
    .then((r) => {
      saveJwtToken(r.data.token);
      saveRefreshToken(r.data.refreshToken);
    })
    .catch((e) => {
      handleRedirectToLogin();
    });
};

export const post = async (url, payload) => {
  return axios
    .post(url, payload)
    .then((r) => {
      return r;
    })
    .catch((r) => r.response);
};

export const get = async (url, payload) => {
  return axios
    .get(url, payload)
    .then((r) => {
      return r;
    })
    .catch((r) => {
      if (r.response.status === 401) {
        //refresh();
      }
    });
};
