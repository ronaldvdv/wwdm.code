import { Link } from "gatsby";
import React from "react"


function EpisodeList({ seasonIndex, episodes }) {
return <ul>
    {episodes.map(e => <li><Link to={`/seizoen-${seasonIndex}/aflevering-${e.index}`}>{e.code} {e.title}</Link></li>)}
</ul>;
}

export default ({ data }) => <aside>
    <h3>Overzicht</h3>

    <h3>Afleveringen</h3>
    <EpisodeList seasonIndex={data.index} episodes={data.episodes} />
        
    <h3>Kandidaten</h3>
</aside>