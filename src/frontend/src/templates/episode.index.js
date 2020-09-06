import React from "react"

export default function page({ data }) {
    data = data.wwdm.episode;
    return <h1>This is a header for episode <span>{data.index}</span>: {data.title} ({data.season.recordingCountries})</h1>
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
        }        
    }
  }
  `;