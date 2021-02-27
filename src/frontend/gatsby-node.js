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
                    games {
                      id, title
                    }
                }
            }
        }
      }
    `)

    let seasons = result.data.wwdm.seasons;
    seasons.forEach(s => {
        if(s.index < 18)
        {
          return;
        }
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

            e.games.forEach(g => {
              createPage({
                path: '/seizoen-' + s.index + '/aflevering-' + e.index + '/opdrachten/' + g.id + '-test',
                component: path.resolve('./src/templates/game.index.js'),
                context: { id: g.id }
              });
            });
        });
    });

}