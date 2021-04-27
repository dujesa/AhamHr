import axios from "axios";

export const getJwtToken = () => {
  localStorage.getItem("token");
};

export const getRefreshToken = () => {
  localStorage.getItem("refreshToken");
};

export const saveJwtToken = (token) => {
  localStorage.setItem("token", token);
};

export const saveRefreshToken = (refreshToken) => {
  localStorage.setItem("refreshToken", refreshToken);
};

export const handleRedirectToLogin = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("refreshToken");
  localStorage.removeItem("userId");
  history.push("/login");
};

export const refresh = () => {
  const jwtToken = getJwtToken();
  axios.defaults.headers.common["Authorization"] = `Bearer ${jwtToken}`;
  axios
    .get(`api/Account/RefreshToken?token=${token}`)
    .then((r) => {
      saveJwtToken(r.data.token);
      saveRefreshToken(r.data.refreshToken);
    })
    .catch((e) => {
      handleRedirectToLogin();
    });
};
