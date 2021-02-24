import React from "react"

export default function view({menu, body})
{
    return <div>
        <nav className="navbar navbar-expand-lg navbar-dark bg-primary">
            <div className="container-fluid">
                <a className="navbar-brand" href="#">WWDM</a>
                <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>       

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav mr-auto">
                    <li className="nav-item active">
                        <a className="nav-link" href="/">Home</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/seizoenen">Seizoenen</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/deelnemers/mollen">Mollen</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/opdrachten">Opdrachten</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/geld">Geld</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/kijkcijfers">Kijkcijfers</a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link" href="/kaart">Kaart</a>
                    </li>
                </ul>
                <form className="d-flex">
                    <input className="form-control mr-sm-2" type="search" placeholder="Zoeken" aria-label="Zoeken"></input>
                    <button className="btn btn-primary my-2 my-sm-0" type="submit">Zoeken</button>
                </form>            
            </div>            
        </div>
        </nav>
        <div className="container">
            <header>{menu}</header>
            <div>
                {body}
            </div>
        </div>
    </div>;
}