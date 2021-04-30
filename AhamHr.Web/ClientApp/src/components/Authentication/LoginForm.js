import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { loginUser } from "../../services/data";
import { getJwtToken, saveJwtToken } from "../../services/jwtHandler";
import { constructUser } from "../../utils/defaults";
import { validateUserForLogin } from "../../utils/validation";

const LoginForm = () => {
  const [user, setUser] = useState(constructUser());

  const handleInputChange = ({ target: { name, value } }) => {
    setUser((prevUser) => ({
      ...prevUser,
      [name]: value,
    }));
  };

  const handleLogin = async () => {
    if (!validateUserForLogin(user)) {
      return;
    }

    const token = await loginUser(user);
    saveJwtToken(token);
  };

  return (
    <div>
      <h1>Login</h1>
      <form>
        <input
          type="text"
          name="email"
          placeholder="Email"
          value={user.email}
          onChange={handleInputChange}
        />
        <input
          type="text"
          name="password"
          placeholder="Lozinka"
          value={user.password}
          onChange={handleInputChange}
        />
      </form>
      <button onClick={handleLogin}>prijava</button>
      <p>
        Nemaš račun?<Link to="/auth/register">Registriraj se.</Link>
      </p>
    </div>
  );
};

export default LoginForm;
