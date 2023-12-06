import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Navbar } from './Components/NavBar';
import { Lobby } from './Pages/Lobby';
import { Main } from './Pages/Main/Main';

function App() {
  return (
    <div className="App">
      <Router>
        <Navbar />
        <Routes>
          <Route path ="/" element={<Main/>} />   
          <Route path ="/lobby" element={<Lobby/>} /> 
          <Route path="*" element={<h1>Error</h1>} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
