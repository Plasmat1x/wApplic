import React, { useState } from "react";
import { json, useNavigate } from "react-router-dom";
import "./Login.css";

function Login() {
    const [username, setUsername] = useState("");
    const [usernameError, setUsernameError] = useState("");
    const [password, setPassword] = useState("");
    const [passwordError, setPasswordError] = useState("");
    const [token, setToken] = useState("");

    const navigate = useNavigate();

    const onButtonClick = () => {
        setUsernameError("")
        setPasswordError("")

        if ("" === username) {
            setUsernameError("Please enter your username")
            return
        }

        if ("" === password) {
            setPasswordError("Please enter a password")
            return
        }

        if (password.length < 7) {
            setPasswordError("The password must be 8 characters or longer")
            return
        }

        var response = fetch("https://localhost:7000/Account/Login",
            {
                mode: "cors",
                method: "POST",
                headers: {
                    'Content-Type': "application/json"
                },
                body: JSON.stringify({
                    username,
                    password
                }),
            }
        )
            .then(response => response.json())
            .then(data => setToken(data));

        alert(localStorage.getItem("user"));
    }

    return (
        <>
            <div>
                <p>token: {token.token}</p>
                <p>expire: {token.expiration}</p>
            </div>
            <div className={"mainContainer"}>
                <div className={"titleContainer"}>
                    <div>Login</div>
                </div>
                <br />
                <div className={"inputContainer"}>
                    <input
                        value={username}
                        placeholder="Enter your username here"
                        onChange={ev => setUsername(ev.target.value)}
                        className={"inputBox"} />
                    <label className="errorLabel">{usernameError}</label>
                </div>
                <br />
                <div className={"inputContainer"}>
                    <input
                        value={password}
                        placeholder="Enter your password here"
                        onChange={ev => setPassword(ev.target.value)}
                        className={"inputBox"} />
                    <label className="errorLabel">{passwordError}</label>
                </div>
                <br />
                <div className={"inputContainer"}>
                    <input
                        className={"inputButton"}
                        type="button"
                        onClick={onButtonClick}
                        value={"Log in"} />
                </div>
            </div>
        </>
    );
}

export default Login;