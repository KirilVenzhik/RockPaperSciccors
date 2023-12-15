import './App.css'
import { useEffect } from 'react'
import axios, { AxiosResponse } from 'axios'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Navbar } from './Components/NavBar'
import { Lobby } from './Pages/Lobby'
import { Main } from './Pages/Main/Main'
import { I18nextProvider } from 'react-i18next'
import i18n from './Components/Language'

function App() {
    useEffect(() => {
        axios.get('https://localhost:7284/api/Game').then((response: AxiosResponse<any>) => {
            console.log(response.data)
        })
    }, [])

    return (
        <div className="App">
            <I18nextProvider i18n={i18n}>
                <Router>
                    <Navbar />

                    <Routes>
                        <Route path="/" element={<Main />} />
                        <Route path="/lobby" element={<Lobby />} />
                        <Route path="*" element={<h1>Error</h1>} />
                    </Routes>
                </Router>
            </I18nextProvider>
        </div>
    )
}

export default App
