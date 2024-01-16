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
                <div key={a.id} className="article">
                    <h2>{a.title}</h2>
                    <p>{a.description}</p>
                    <p>Author: {author(a.authorId)}</p>
                    <Link to={{
                        pathname: `article/${a.id}`,
                        state: { id: a.id }
                    }}>More
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
        const response = await fetch('https://localhost:7000/api/Article/All', { mode: "cors" })
            .then(r => r.json())
            .then(d => setArticles(d));
    }

    function author(id) {
        var author = "";
        fetch(`https://localhost:7000/api/user/${id}`, { mode: 'cors' })
            .then(r => r.json())
            .then(d => author = d.username);

        return author;
    }
}

export default Home;