import { BrowserRouter as Router, Routes, Route, Link, Outlet } from 'react-router-dom';
import "./Layout.css"

export default function Layout() {
    return (
        <>
            <nav>
                <div>
                    <img src="vite.svg"></img>
                </div>
                <div>
                    <ul>
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/Articles">Articles</Link>
                        </li>
                        <li>
                            <Link to="/About">About</Link>
                        </li>
                        <li>
                            <Link to="/Weather">Weather</Link>
                        </li>
                        <li>
                            <Link to="/Article">Article</Link>
                        </li>
                    </ul>
                </div>
                <div>
                    <ul>
                        <li>
                            <Link to="/Login">Login</Link>
                        </li>
                        <li>
                            <Link to="/Register">Register</Link>
                        </li>
                    </ul>
                </div>

            </nav>

            <Outlet />
        </>
    );
}


/*
import MenuBar from "./MenuBar";
import MenuBar2 from "./MenuBar2";
import { BrowserRouter as Router, Routes, Route, Link, Outlet } from 'react-router-dom';
function Layout() {
    return (
        <>
            <MenuBar2 />
            <Outlet />
        </>
    );
}

export default Layout;
*/