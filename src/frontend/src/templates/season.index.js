import React from "react"
import Layout from "../components/Layout";
import { Link } from "gatsby";
import Header from "../components/seasons/Header";
import Menu from "../components/seasons/Menu";
import Panel from "../components/general/Panel";

function primaryEpisode(episode, season) {

}

export default function view({ data }) {
  data = data.wwdm.season;
  return (<Layout
    menu={<Menu data={data}/>}
    header={<Header data={data}/>}
    body={      
      <div>
        <Panel color="primary" title="Afleveringen" figure={<figure>Image</figure>}>
          Tekstje
        </Panel>

        <Panel color="primary" title="Kandidaten" figure={<figure>Image</figure>}>
          Tekstje23
        </Panel>

        <div className="col-12 col-md-6">
          Tekstje
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
              index, title, code
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