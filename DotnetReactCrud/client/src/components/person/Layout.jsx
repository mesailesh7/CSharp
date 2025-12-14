import React from "react";
import { Outlet } from "react-router-dom";
import Navbar from "./NavBar";

const Layout = ({ children }) => {
  return (
    <>
      <Navbar />
      <main>{children ? children : <Outlet />}</main>
    </>
  );
};

export default Layout;
