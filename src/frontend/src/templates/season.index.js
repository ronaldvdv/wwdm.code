import React from "react"
import Img from "gatsby-image"

export default function blogpost({ data }) {
    data = data.wwdm.season;
    return <h1>This is a header for season <span>{data.index}</span>: {data.recordingCountries} <Img fluid={data.image.imageFile.childImageSharp.fluid}/> <pre>{JSON.stringify(data)}</pre></h1>
}

export const query = graphql`
  query($id: Int!) {
    wwdm {
        season(id: $id) {
            index, recordingCountries
            image {
              id
              imageFile {
                absolutePath
                childImageSharp {
                    fluid(maxWidth: 700) {
                      ...GatsbyImageSharpFluid
                    }
                  }
              }
            }
        }        
    }
  }
`;