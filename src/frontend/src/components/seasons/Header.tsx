import React from "react"
import Img from "gatsby-image"

export default ({ data }) => <header className="jumbotron">
    <h1>{ data.recordingCountries }</h1>
    <figure>
        <Img fluid={data.image.imageFile.childImageSharp.fluid}/>
    </figure>
</header>;