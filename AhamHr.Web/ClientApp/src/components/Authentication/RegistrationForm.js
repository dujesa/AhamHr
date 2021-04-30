import React, { useState } from "react";
import { Link } from "react-router-dom";

import { registerUser } from "../../services/data";
import { saveJwtToken } from "../../services/jwtHandler";
import { constructUser } from "../../utils/defaults";
import { validateUser } from "../../utils/validation";

const RegistrationForm = () => {
  const [user, setUser] = useState(constructUser());

  const handleInputChange = ({ target: { name, value } }) => {
    setUser((prevUser) => ({
      ...prevUser,
      [name]: value,
    }));
  };

  const handleCheckboxChange = ({ target: { name } }) => {
    setUser((prevUser) => {
      return {
        ...prevUser,
        [name]: !prevUser[name],
      };
    });
  };

  const handleRegistration = async () => {
    if (!validateUser(user)) {
      return;
    }

    const token = await registerUser(user);
    saveJwtToken(token);
  };

  return (
    <div>
      <h1>Registracija</h1>
      <form>
        <input
          type="text"
          name="firstName"
          placeholder="Ime"
          value={user.firstName}
          onChange={handleInputChange}
        />
        <input
          type="text"
          name="lastName"
          placeholder="Prezime"
          value={user.lastName}
          onChange={handleInputChange}
        />
        <input
          type="text"
          name="phoneNumber"
          placeholder="Broj mobitela"
          value={user.phoneNumber}
          onChange={handleInputChange}
        />
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
        <input
          type="text"
          name="repeatedPassword"
          placeholder="Ponovi lozinku"
          value={user.repeatedPassword}
          onChange={handleInputChange}
        />
        <input
          type="checkbox"
          name="termsAndConditions"
          value={user.termsAndConditions}
          onChange={handleCheckboxChange}
        />
        <label htmlFor="termsAndConditions">
          Slažem se s uvjetima i odredbama.
        </label>
        <input
          type="checkbox"
          name="newsletter"
          value={user.newsletter}
          onChange={handleCheckboxChange}
        />
        <label htmlFor="termsAndConditions">
          Želim biti u toku s novostima iz svijeta edukacije.
        </label>
      </form>
      <button onClick={handleRegistration}>Registriraj se</button>
      <p>
        Nemaš račun?<Link to="/auth/login">Prijavi se.</Link>
      </p>
    </div>
  );
};

export default RegistrationForm;
