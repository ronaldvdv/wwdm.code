import React from "react"
import Img from "gatsby-image"
import Layout from "../components/Layout";
import { Link } from "gatsby";

function EpisodeList({ seasonIndex, episodes })
{
  return <ul>
    {episodes.map(e => <li><Link to={`/seizoen-${seasonIndex}/aflevering-${e.index}`}>Aflevering {e.index}</Link></li>)}
  </ul>;
}

export default function view({ data }) {
    data = data.wwdm.season;
    return<Layout 
    menu={<h1>This is a header for season <span>{data.index}</span>: {data.recordingCountries}</h1>}
    body={<div><Img fluid={data.image.imageFile.childImageSharp.fluid}/>Image: #{data.image.id} @ {data.image.absolutePath} <EpisodeList seasonIndex={data.index} episodes={data.episodes}/></div>
    //body={<div>{JSON.stringify(data.image)}</div>

  }
    />;
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
                  fluid(maxWidth: 1200) {
                    ...GatsbyImageSharpFluid
                  }
                }
              }

            }
        }        
    }
  }
`;