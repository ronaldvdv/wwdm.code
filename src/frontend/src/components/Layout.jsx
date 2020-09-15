import React from "react"

export default function view({menu, body})
{
    return <div>
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
            <a class="navbar-brand" href="#">WWDM</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>       

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="/">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/seizoenen">Seizoenen</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/deelnemers/mollen">Mollen</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/opdrachten">Opdrachten</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/geld">Geld</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/kijkcijfers">Kijkcijfers</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="/kaart">Kaart</a>
                </li>
            </ul>
            <form class="form-inline my-2 my-lg-0">
                <input class="form-control mr-sm-2" type="search" placeholder="Zoeken" aria-label="Zoeken"></input>
                <button class="btn btn-primary my-2 my-sm-0" type="submit">Zoeken</button>
            </form>            
        </div>
        </nav>
        <div class="container">
            <header>{menu}</header>
            <div>
                {body}
            </div>
        </div>
    </div>;
}