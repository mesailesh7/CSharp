import { useEffect, useState } from "react";
import "./App.css";

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    fetch("https://localhost:5001/api/activities")
      .then((response) => response.json())
      .then((data) => setActivities(data));
  }, []);

  return (
    <>
      <h3>Reactivities</h3>
      <ul>
        {activities.map((activity, index) => {
          <li key={index}>{activity.title}</li>;
        })}
      </ul>
    </>
  );
}

export default App;
