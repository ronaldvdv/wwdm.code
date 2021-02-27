import React from "react"
import Img from "gatsby-image"
import Layout from "../components/Layout";
import { Link } from "gatsby";

function GameList({ seasonIndex, episodeIndex, games }) {
  return <ul>
    {games.map(g => <li><Link to={`/seizoen-${seasonIndex}/aflevering-${episodeIndex}/opdrachten/${g.id}-test`}>Opdracht {g.id}</Link></li>)}
  </ul>;
}

export default function page({ data }) {
    data = data.wwdm.episode;
    console.log(data);
    return<Layout 
    menu={<h1>This is a header for episode <span>{data.index}</span>: {data.title} ({data.season.recordingCountries})</h1>}
    body={
    <div>
      { data.image.imageFile.childImageSharp != null && <Img fluid={data.image.imageFile.childImageSharp.fluid}/> }
      <Link to={`/seizoen-${data.season.index}`}>Naar seizoen {data.season.index}</Link>
      <GameList seasonIndex={data.season.index} episodeIndex={data.index} games={data.games}/>
    </div>
    }

    />;
}

export const query = graphql`
  query($id: Int!) {
    wwdm {
      episode(id: $id) {
        index, title
        season {
          id, index
          recordingCountries                
        }
        games {
          id, title
          image {
            id, absolutePath, extension
            imageFile {
              childImageSharp {
                id
                fluid(maxWidth: 800) {
                  ...GatsbyImageSharpFluid
                }
              }
            }   
            
          }
        }
        image {
          id, absolutePath, extension
          imageFile {
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