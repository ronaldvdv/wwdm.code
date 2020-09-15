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

exports.onCreateNode = ({  node, actions, getNode }) => {
  var type = node.internal.type;
  if(type == "SitePage" || type == "File")
  {
    return;
  }
  console.log(`Node created of type "${node.internal.type}": ${node}`)
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
          console.log('Source:', source);
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
          console.log('Node:', node);
          await createNode(node, {name:'gatsby-source-filesystem'});
          return node;
        },
      },
    },
  })
}