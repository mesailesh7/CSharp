import { useEffect, useState } from "react";
import PersonForm from "./PersonForm";
import PersonList from "./PersonList";
import { useForm } from "react-hook-form";
import toast, { Toaster } from "react-hot-toast";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import authService from "../../services/authService";

function Person() {
  const BASE_URL = import.meta.env.VITE_BASE_API_URL + "/people";

  const [people, setPeople] = useState([]);
  const [loading, setLoading] = useState(true);
  const [editData, setEditData] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const loadPeople = async () => {
      try {
        const response = await axios.get(BASE_URL);
        setPeople(response.data);
      } catch (error) {
        if (error.response && error.response.status === 401) {
          toast.error("Session expired. Please log in again.");
          authService.logout();
          navigate("/login");
        } else {
          toast.error("An error occurred while fetching data.");
        }
      } finally {
        setLoading(false);
      }
    };

    loadPeople();
  }, []);

  useEffect(
    (person) => {
      methods.reset(editData);
    },
    [editData]
  );

  const defaultFormValues = {
    id: 0,
    firstName: "",
    lastName: "",
  };

  const methods = useForm({
    defaultValues: defaultFormValues,
  });

  const handlePersonEdit = (person) => {
    setEditData(person);
  };

  const handlePersonDelete = async (person) => {
    if (
      !confirm(
        `Are you sure to delete a person : ${person.firstName} ${person.lastName}`
      )
    )
      return;
    setLoading(true);
    try {
      await axios.delete(`${BASE_URL}/${person.id}`);
      setPeople((previousPerson) =>
        previousPerson.filter((p) => p.id !== person.id)
      );
    } catch (error) {
      if (error.response && error.response.status === 401) {
        authService.logout();
        navigate("/login");
      } else if (error.response && error.response.status === 403) {
        toast.error("You are not authorized to perform this action.");
      }
      toast.error("Error on deleting");
    } finally {
      setLoading(false);
    }
  };

  const handleFormReset = () => {
    methods.reset(defaultFormValues);
  };

  const handleFormSubmit = async (person) => {
    setLoading(true);
    try {
      if (person.id <= 0) {
        console.log("add");
        const createdPerson = (await axios.post(BASE_URL, person)).data;
        // setPeople((previousPerson) => [...previousPerson, person]);
        setPeople((previousPerson) => [...previousPerson, createdPerson]);
      } else {
        console.log("edit");
        await axios.put(`${BASE_URL}/${person.id}`, person);
        setPeople((previousPeople) =>
          previousPeople.map((p) => (p.id === person.id ? person : p))
        );
      }
      methods.reset(defaultFormValues);
      toast.success("Saved successfully");
    } catch (error) {
      if (error.response && error.response.status === 401) {
        authService.logout();
        navigate("/login");
      } else {
        toast.error("Error has occured");
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="min-h-screen bg-gray-50 py-8">
      <Toaster position="top-right" reverseOrder={false} />
      <div className="max-w-4xl mx-auto px-4 sm:px-6 lg:px-8 space-y-6">
        <div className="text-center mb-8">
          <h1 className="text-3xl font-bold bg-gradient-to-r from-blue-600 to-purple-600 bg-clip-text text-transparent">
            Person Management
          </h1>
          {loading && <p>Loading...</p>}
        </div>

        {/* //Note: so Person is the parent component which is the smart component
        and PersonForm and PersonList and child component which is also a dumb
        component that only can execute but all the function and data are being
        pass from the parent component */}
        <PersonForm
          methods={methods}
          onFormReset={handleFormReset}
          onFormSubmit={handleFormSubmit}
        />
        <PersonList
          people={people}
          onPersonDelete={handlePersonDelete}
          onPersonEdit={handlePersonEdit}
        />
      </div>
    </div>
  );
}

export default Person;
