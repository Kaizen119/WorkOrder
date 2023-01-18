import React from 'react'
import './App.css';
import {Routes, Route, Navigate} from 'react-router-dom'
import Dashboard from './components/Dashboard';


function App() {
  return (
  <div className="App">
    <Routes>
      <Route path='/dashboard' element={<Dashboard />}/>


      {/* Redirect */}
      <Route path='*' element={<Navigate to="/dashboard" replace/>}/>
    </Routes>
  </div>
  );
}




export default App;