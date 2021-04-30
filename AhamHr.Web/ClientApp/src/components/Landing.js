import React from "react";

import Button from "./Button";
import Layout from "./Layout";
import ProfessorList from "./Professors/ProfessorList";

const Landing = () => {
  const button = <Button link= "/auth/login" content= "prijavi se" />
  return (
    <Layout button={button}>
      <h1>Aham!</h1>
      <input type="text"></input>
      <ProfessorList />
    </Layout>
  );
};

export default Landing;
