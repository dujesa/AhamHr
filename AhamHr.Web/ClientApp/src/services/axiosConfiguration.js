import axios from "axios";
import { getJwtToken, handleRedirectToLogin, saveJwtToken } from "./jwtHandler";

const configureForRequest = () => {
  axios.interceptors.request.use((config) => {
    const token = `Bearer ${localStorage.getItem("token")}`;
    config.headers["Authorization"] = token;

    return config;
  });
};

const configureForResponse = () => {
  axios.interceptors.response.use(
    (response) => response,
    (error) => {
      let originalRequest = error.config;
      const token = getJwtToken();

      if (!error.response || error.response.status !== 401) {
        return Promise.reject(error);
      }

      if (token && originalRequest && !originalRequest._isRetryRequest) {
        originalRequest._isRetryRequest = true;

        return newToken(token).then(({ data }) => {
          if (!data) {
            handleRedirectToLogin();
            return;
          }

          saveJwtToken(data);
          return axios(originalRequest);
        });
      }

      handleRedirectToLogin();
      return Promise.reject(error);
    }
  );
};

const configureAxios = () => {
  axios.defaults.headers.post["Content-Type"] = "application/json";

  configureForRequest();
  configureForResponse();
};

export default configureAxios;
