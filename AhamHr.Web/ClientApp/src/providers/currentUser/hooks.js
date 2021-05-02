import { useContext } from "react";
import { CurrentUserContext } from ".";

const useCurrentUserContext = () => {
  return useContext(CurrentUserContext);
};

export const useCurrentUser = () => {
  const {
    state: { currentUser },
    setCurrentUser,
  } = useCurrentUserContext();

  return [currentUser, setCurrentUser];
};
