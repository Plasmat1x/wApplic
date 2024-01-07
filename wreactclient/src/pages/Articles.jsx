import { useEffect, useState } from "react";
import Time from "react-time-format";
import "./Articles.css";

function Articles() {
    const [articles, setArticles] = useState();

    useEffect(() => {
        getArticles();
    }, []);

    const contents = articles == undefined
        ? <p>Not loaded</p>
        :
        <div className="content">
            <table className="table table-striped">
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Description</th>
                        <th>CreatedAt</th>
                        <th>LastUpdatedAt</th>
                    </tr>
                </thead>
                <tbody>
                    {articles.map((a) =>
                        <tr key={a.id}>
                            <td>{a.title}</td>
                            <td>{a.description}</td>
                            <td><Time value={a.createdAt} format="DD/MM/YYYY HH:mm" /></td>
                            <td><Time value={a.lastUpdatedAt} format="DD/MM/YYYY HH:mm" /></td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>

    return (
        <>
            <div>
                <h1>Articles</h1>
            </div>
            {contents}
        </>

    );

    async function getArticles() {
        const response = await fetch('https://localhost:7000/api/Article/All', { mode: "cors" });
        const data = await response.json();
        setArticles(data);
    }
}

export default Articles;
