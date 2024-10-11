import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import App from './App.jsx'
import './index.css'
import './index.scss'
import { ContentContextProvider } from './Context/ContentContext.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <ContentContextProvider>
      <App />
    </ContentContextProvider>
  </StrictMode>,
)
