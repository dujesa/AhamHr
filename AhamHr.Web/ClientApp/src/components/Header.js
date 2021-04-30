import React from "react";
import { Link } from "react-router-dom";

const Header = ({ backLink, button }) => {

  return (
    <header>
      <nav>
        {!!backLink && <Link to={backLink}>&lt;</Link>}
        {!!button && button}
      </nav>
    </header>
  );
};

export default Header;
