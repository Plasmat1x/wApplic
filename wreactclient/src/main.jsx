//initial
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
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
import Article from './pages/Article';

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
                    <Route exact path="article/:id" element={<Article />} />
                    <Route path="*" element={<NoPage />} />
                </Route>
            </Routes>
        </BrowserRouter>
    </React.StrictMode>,
)
