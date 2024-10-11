import React, { useContext } from "react";
import Header from "./Header";
import MainBodyCompartments from "./MainBodyCompartments";
import { ContentContext } from "../Context/ContentContext";

const MainBody = () => {
  const { tasks, setTasks } = useContext(ContentContext);
  
  // Function to delete a task
  const handleCategorySts = (id) => {
    setTasks((prev) => prev.filter((taskobj) => taskobj.id !== id));
  };

  // Function to move a task to Ongoing
  const handleCategoryStatus1 = (id) => {
    setTasks((prev) =>
      prev.map((taskobj) =>
        taskobj.id === id ? { ...taskobj, category: "Ongoing" } : taskobj
      )
    );
  };

  // Function to move a task to Completed
  const handleCategoryStatus2 = (id) => {
    setTasks((prev) =>
      prev.map((taskobj) =>
        taskobj.id === id ? { ...taskobj, category: "Completed" } : taskobj
      )
    );
  };

  return (
    <div className="mainBodyDiv">
      <div className="MainBodyContentDiv1">
        <h2>PENDING</h2>
        {tasks.map((taskobj) =>
          taskobj.category === "Pending" ? (
            <div key={taskobj.id}>
              <MainBodyCompartments h3={taskobj.task} />
              <button onClick={() => handleCategoryStatus1(taskobj.id)}>Move to Ongoing</button>
              <button onClick={() => handleCategorySts(taskobj.id)}>Delete</button>
            </div>
          ) : null
        )}
      </div>
      <div className="MainBodyContentDiv2">
        <h2>ONGOING</h2>
        {tasks.map((taskobj) =>
          taskobj.category === "Ongoing" ? (
            <div key={taskobj.id}>
              <MainBodyCompartments h3={taskobj.task} />
              <button onClick={() => handleCategoryStatus2(taskobj.id)}>Move to Completed</button>
              <button onClick={() => handleCategorySts(taskobj.id)}>Delete</button>
            </div>
          ) : null
        )}
      </div>
      <div className="MainBodyContentDiv3">
        <h2>COMPLETED</h2>
        {tasks.map((taskobj) =>
          taskobj.category === "Completed" ? (
            <div key={taskobj.id}>
              <MainBodyCompartments h3={taskobj.task} />
              <button onClick={() => handleCategorySts(taskobj.id)}>Delete</button>
            </div>
          ) : null
        )}
      </div>
    </div>
  );
};

export default MainBody;
