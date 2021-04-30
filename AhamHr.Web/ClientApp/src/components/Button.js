import React from "react";

import { Link } from "react-router-dom";

const Button = ({ content, link }) => {
  return (
    <Link to={link}>
      <button>{content}</button>
    </Link>
  );
};

export default Button;
