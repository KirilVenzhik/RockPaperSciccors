import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Navbar } from './Components/NavBar';
import { Lobby } from './Pages/Lobby';
import { Main } from './Pages/Main/Main';
import { I18nextProvider } from 'react-i18next';
import i18n from './Components/Language';

function App() {
  return (
    <div className="App">
      <I18nextProvider i18n={i18n}>
        <Router>
          <Navbar />
          <Routes>
            <Route path ="/" element={<Main/>} />   
            <Route path ="/lobby" element={<Lobby/>} /> 
            <Route path="*" element={<h1>Error</h1>} />
          </Routes>
        </Router>
      </I18nextProvider>
    </div>
  );
}

export default App;
