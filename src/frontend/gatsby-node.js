const path = require(`path`);

exports.createPages = async ({ graphql, actions }) => {
    const { createPage } = actions;
    const result = await graphql(`
      query {
        wwdm {
            seasons {
                index, recordingCountries, id
                episodes {
                    id, index, title
                }
            }
        }
      }
    `)

    console.log(JSON.stringify(result.data));

    let seasons = result.data.wwdm.seasons;
    seasons.forEach(s => {
        createPage({
            path: '/seizoen-' + s.index,
            component: path.resolve(`./src/templates/season.index.js`),
            context: { id: s.id },
        });

        s.episodes.forEach(e => {
            createPage({
                path: '/seizoen-' + s.index + '/aflevering-' + e.index,
                component: path.resolve('./src/templates/episode.index.js'),
                context: { id: e.id }
            });
        });
    });

}

exports.onCreateNode = ({ node }) => {
    console.log(`Node created of type "${node.internal.type}"`)
}