import { createContext, useState, useEffect } from "react";
import { task } from "../../../data";

export const  ContentContext = createContext();
export const ContentContextProvider = ({children}) => {
    const [tasks, setTasks] = useState(() => {
        const savedTasks = JSON.parse(localStorage.getItem('tasks'));
        return savedTasks || task;  // Use saved tasks or default tasks if no saved tasks
    });
    const [newTask, setNewTask] = useState('');
    
    // Function to update tasks in local storage
    const saveTasksToLocalStorage = (tasks) => {
    localStorage.setItem('tasks', JSON.stringify(tasks));
  };
  // Whenever the tasks state changes, save the updated tasks to localStorage
  useEffect(() => {
    
    saveTasksToLocalStorage(tasks);
  }, [tasks]);
   
    
    const handleSubmit=()=>{
        
        if (newTask.trim() === '') return; // Prevent empty tasks 
        const newTaskObj ={
            id: tasks.length + 1,
            category:"Pending",
            task: newTask
        };
        setTasks((prevTasks) => [...prevTasks, newTaskObj]);
        // Clear the input field
        setNewTask('');
    }
return(
    <ContentContext.Provider value={{tasks, setTasks, newTask, setNewTask, handleSubmit }}>
        {children}
    </ContentContext.Provider>
)
}
