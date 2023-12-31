//initial
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import './index.css';

//pages
import Home from './pages/Home';
import Layout from './pages/Layout';
import Articles from './pages/Articles';
import About from './pages/About';
import Register from './pages/Register';
import Login from './pages/Login';
import NoPage from './pages/NoPage';
import Weather from './pages/WeatherForecast';

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Layout />}>
                    <Route index element={<Home />} />
                    <Route path="articles" element={<Articles />} />
                    <Route path="about" element={<About />} />
                    <Route path="login" element={<Login />} />
                    <Route path="register" element={<Register />} />
                    <Route path="weather" element={<Weather />} />
                    <Route path="*" element={<NoPage />} />
                </Route>
            </Routes>
        </BrowserRouter>
  </React.StrictMode>,
)
