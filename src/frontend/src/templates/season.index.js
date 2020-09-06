import React from "react"



export default function blogpost({ data }) {
    data = data.wwdm.season;
    return <h1>This is a header for season <span>{data.index}</span>: {data.recordingCountries}</h1>
}

export const query = graphql`
  query($id: Int!) {
    wwdm {
        season(id: $id) {
            index, recordingCountries
        }        
    }
  }
  `;