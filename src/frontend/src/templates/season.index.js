import React from "react"
import Layout from "../components/Layout";
import { Link } from "gatsby";
import Header from "../components/seasons/Header";
import Panel from "../components/general/Panel";

function EpisodeList({ seasonIndex, episodes }) {
  return <ul>
    {episodes.map(e => <li><Link to={`/seizoen-${seasonIndex}/aflevering-${e.index}`}>Aflevering {e.index}</Link></li>)}
  </ul>;
}

function primaryEpisode(episode, season) {

}

export default function view({ data }) {
  data = data.wwdm.season;
  return (<Layout
    menu={<div>De kandidaten</div>}
    body={
      <div className="row">
        <div className="col-12 col-lg-8">
          <Header data={data} />
          <div className="clearfix"></div>
          <div className="row">
            <div className="col-12 col-md-6">
              <Panel color="primary" title="Afleveringen" figure={<figure>Image</figure>}>
                Tekstje
              </Panel>
            </div>

            <div className="col-12 col-md-6">
              <Panel color="primary" title="Kandidaten" figure={<figure>Image</figure>}>
                Tekstje23
              </Panel>
            </div>

            <div className="col-12 col-md-6">
              <EpisodeList seasonIndex={data.index} episodes={data.episodes} />
            </div>

            <div className="col-12 col-md-6">
              Tekstje
            </div>
          </div>
        </div>
      </div>
    }
  />);
}

export const query = graphql`
  query($id: Int!) {
    wwdm {
        season(id: $id) {
            index, recordingCountries
            episodes {
              index
            }
            image {
              id, absolutePath, extension

              imageFile {
                id
                childImageSharp {
                  id
                  fluid(maxWidth: 800) {
                    ...GatsbyImageSharpFluid
                  }
                }
              }

            }
        }        
    }
  }
`;