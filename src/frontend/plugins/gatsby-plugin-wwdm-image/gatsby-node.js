const { createRemoteFileNode } = require(`gatsby-source-filesystem`)
const path = require(`path`);

exports.createResolvers = async (
    {
      actions,
      createNodeId,
      createContentDigest,
      createResolvers,
      store,
      reporter,
    }, configOptions
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
  