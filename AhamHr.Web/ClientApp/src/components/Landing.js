import React from "react";

import Button from "./Button";
import Layout from "./Layout";

const Landing = () => {
  const button = <Button link= "/auth/login" content= "prijavi se" />
  return (
    <Layout button={button}>
      <h1>Aham!</h1>
      <input type="text"></input>
    </Layout>
  );
};

export default Landing;
