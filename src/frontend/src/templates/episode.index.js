import React from "react"
import Img from "gatsby-image"
import Layout from "../components/Layout";
import { Link } from "gatsby";

export default function page({ data }) {
    data = data.wwdm.episode;

    return<Layout 
    menu={<h1>This is a header for episode <span>{data.index}</span>: {data.title} ({data.season.recordingCountries})</h1>}
    body={<div><Img fluid={data.image.imageFile.childImageSharp.fluid}/><Link to={`/seizoen-${data.season.index}`}>Naar seizoen {data.season.index}</Link></div>}
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
        image {
          id, absolutePath, extension
          imageFile {
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