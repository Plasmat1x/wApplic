import { Outlet, Link } from "react-router-dom";

function Layout() {
    return (
        <>
            <nav>
                <img src="vite.svg"></img>
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
                        <Link to="/Login">Login</Link>
                    </li>
                    <li>
                        <Link to="/Register">Register</Link>
                    </li>
                </ul>
            </nav>

            <Outlet />
        </>
    );
}

export default Layout;