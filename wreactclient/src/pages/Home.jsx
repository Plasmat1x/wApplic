import { useEffect, useState } from "react";
import Time from "react-time-format";
import "./Home.css";

function Home() {
    const [articles, setArticles] = useState();

    useEffect(() => {
        getArticles();
    }, []);

    const contents = articles == undefined
        ? <p>Not loaded</p>
        :
        <div>
            {articles.map((a) =>
                <div className="article">
                    <h2>{a.title}</h2>
                    <div>
                        <p>{a.description}</p>
                    </div>
                    <div className="data-part">
                        <div>
                            <p>Aurhor:</p>
                            <p>{a.authorId}</p>
                        </div>
                        <div>
                            <p>Created at:</p>
                            <p><Time value={a.createdAt} format="DD/MM/YYYY HH:mm" /></p>
                        </div>
                        <div>
                            <p>Last updated:</p>
                            <p><Time value={a.lastUpdatedAt} format="DD/MM/YYYY HH:mm" /></p>
                        </div>
                    </div>
                    <hr></hr>
                </div>

            )}
        </div>

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
}

export default Home;