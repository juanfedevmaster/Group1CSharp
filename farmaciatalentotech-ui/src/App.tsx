import './App.css'
import { useState } from 'react'
import Login from './components/Login.tsx'
import Dashboard from './components/Dashboard.tsx'

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <div className="w-100 m-0 p-0">
      {!isLoggedIn ? <Login onLoginSuccess={() => setIsLoggedIn(true)} /> : <Dashboard />}
    </div>
  )
}

export default App
