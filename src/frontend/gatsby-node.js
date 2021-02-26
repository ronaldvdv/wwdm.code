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
        createPage({
            path: '/seizoen-' + s.index,
            component: path.resolve(`./src/templates/season.index.js`),
            context: { id: s.id },
        });

        /*s.episodes.forEach(e => {
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
        });*/
    });

}

exports.onCreateNode = ({  node, actions, getNode }) => {
  var type = node.internal.type;  
}

/* --------- gatsby-node.js --------- */

const { createRemoteFileNode } = require(`gatsby-source-filesystem`)

/*exports.createSchemaCustomization = ({ actions }) => {
  const { createTypes } = actions
  const typeDefs = `
    type ImageFile implements Node {
      extension: String!
      absolutePath: String!
      id: Int!
    }
  `
  createTypes(typeDefs)
}*/

exports.createResolvers = async (
  {
    actions,
    createNodeId,
    createContentDigest,
    createResolvers,
    store,
    reporter,
  },
) => {
  const { createNode } = actions

  await createResolvers({
    WwdmGraph_Image: {
      imageFile: {
        type: 'File',
        async resolve(source, args, context, info) {
          let data = {
            id: source.id,
            absolutePath: path.resolve('../../data/private/shots/', source.absolutePath),
            extension: 'jpg',
            ext: '.jpg'
          }
          let node = {
            ...data,
            id: createNodeId('ImageFile-'+source.id),
            internal: {
              type: 'File',
              contentDigest: createContentDigest(data)
            }
          };
          await createNode(node, {name:'gatsby-source-filesystem'});
          return node;
        },
      },
    },
  })
}

exports.onCreateWebpackConfig = ({ stage, actions }) => {
  if (stage.startsWith("develop")) {
    actions.setWebpackConfig({
      resolve: {
        alias: {
          "react-dom": "@hot-loader/react-dom",
        },
      },
    })
  }
}