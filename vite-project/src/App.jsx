import { useState } from 'react'
import './App.css'
import MainBody from './Components/MainBody'
import Header from './Components/Header'

const App = ()=>{
  

  return (
    <>
    <div className="app-container">
      <Header/>
      <MainBody/>
    </div>
    </>
  )
}

export default App
