import React, { createContext, useState } from "react";

const initialState = {
  currentUser: null,
};

export const CurrentUserContext = createContext({
  state: { ...initialState },
  setCurrentUser: () => {},
});

const CurrentUserProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useState(null);

  const value = {
    state: { currentUser },
    setCurrentUser,
  };

  return (
    <CurrentUserContext.Provider value={value}>
      {children}
    </CurrentUserContext.Provider>
  );
};

export default CurrentUserProvider;
