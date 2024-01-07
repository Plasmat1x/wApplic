import { useEffect, useState } from "react";
import { useLocation, Link } from "react-router-dom";
import * as React from 'react';
import "./Article.css"


function Home() {
    const [articles, setArticles] = useState();

    useEffect(() => {
        getArticles();
    }, []);

    const contents = articles == undefined
        ?
        <div>
            <p>Not loaded</p>
        </div>
        :
        <div>
            {articles.map((a) =>
                <div className="article">
                    <h2>{a.title}</h2>
                    <p>{a.description}</p>
                    <Link to={{
                        pathname: `article/${a.id}`,
                        state: { id: a.id }
                    }} >More
                    </Link>
                </div>
            )}
        </div >


    return (
        <>
            {contents}
        </>

    );

    async function getArticles() {
        const response = await fetch('https://localhost:7000/api/Article/All', { mode: "cors" });
        const data = await response.json();
        setArticles(data);
    }

    function getUser(id) {
        const response = fetch(`https://localhost:7000/api/User/${id}`, {
            mode: "cors",
            method: "GET",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify(id)
        });
        const data = response.json();
        return data.userName;
    }
}

export default Home;