import React from "react";

import Header from "./Header";
import Footer from "./Footer";

const Layout = ({ backLink, button, children }) => {
  return (
    <div>
      <Header back={backLink} button={button} />
      {children}
      <Footer />
    </div>
  );
};

export default Layout;
