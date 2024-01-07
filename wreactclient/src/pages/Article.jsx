import { useEffect, useState } from "react";
import { useLocation, Link } from "react-router-dom";
import Time from "react-time-format";
import "./Article.css";

export default function Article() {
    const { state } = useLocation();
    const content = article == undefined
        ? <p>Not loaded</p>
        :
        <div className="article">
            <h2>{state.article.title}</h2>
            <div className="data">
                <h5>{state.article.description}</h5>
                <p>{state.article.body}</p>
            </div>
            <hr />
            <div className="info">
                <p>{state.article.author}</p>
                <p>Created: {state.article.createdAt}</p>
                <p>Updated: {state.article.lastUpdated}</p>
            </div>

        </div>

    return (
        <>
            {content}
        </>
    );
}