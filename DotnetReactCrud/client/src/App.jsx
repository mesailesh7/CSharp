import React from "react";
import Navbar from "./components/NavBar";
import Home from "./pages/Home";
import About from "./pages/About";
import NotFound from "./pages/NotFound";
import Person from "./components/person/Person";
import { Routes, Route } from "react-router";

const App = () => {
  return (
    <>
      <Navbar />
      <Routes>
        <Route index element={<Home />} />
        <Route path="about" element={<About />} />
        <Route path="Person" element={<Person />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default App;
