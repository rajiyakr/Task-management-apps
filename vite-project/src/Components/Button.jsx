import React from 'react'

const Button = ({onClick}) => {
  return (
    <>
    <button className='bbutton' onClick={onClick}>Submit Task</button>
    </>
  )
}

export default Button
