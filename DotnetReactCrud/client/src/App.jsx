import { Routes, Route } from "react-router-dom";
import Person from "./components/person/Person";
import Login from "./components/auth/Login";
import Register from "./components/auth/Register";
import ProtectedRoute from "./components/auth/ProtectedRoute";
import Layout from "./components/Layout";
import NotFound from "./pages/NotFound";
import Home from "./pages/Home";
import About from "./pages/About";

const App = () => {
  return (
    <>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />

        {/* Protected Routes with Layout */}
        <Route element={<Layout />}>
          <Route element={<ProtectedRoute />}>
            <Route path="/" element={<Home />} />
            <Route path="/people" element={<Person />} />
            <Route path="/about" element={<About />} />
          </Route>
        </Route>

        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default App;
