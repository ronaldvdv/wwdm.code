import React from "react"
import Img from "gatsby-image"
import Layout from "../components/Layout";
import { Link } from "gatsby";

export default function page({ data }) {
    data = data.wwdm.game;

    return<Layout 
    menu={<h1>This is a header for game <span>{data.index}</span>: {data.title}</h1>}
    body={<div><Img fluid={data.image.imageFile.childImageSharp.fluid}/></div>}
    />;
}

export const query = graphql`
  query($id: Int!) {
    wwdm {
      game(id: $id) {
        title        
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