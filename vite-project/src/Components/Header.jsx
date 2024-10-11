import React from 'react'
import Button from './Button'
import { useState, useContext } from 'react'
import { ContentContext } from '../Context/ContentContext'

const Header = () => {
    
    const {newTask,setNewTask,handleSubmit} = useContext(ContentContext);

    const handleInputChange = (e) =>{
        setNewTask(e.target.value);
    }

   
  return (
    <>
    <div className='headerDiv'>
    <h3>Add New Task</h3>
    <input className='input-header' type="text" placeholder='Add new task' value={newTask} onChange={handleInputChange} />
    <Button onClick={handleSubmit}/>
    </div>
    </>
  )
}

export default Header
