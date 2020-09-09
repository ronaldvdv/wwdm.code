/**
 * Configure your Gatsby site with this file.
 *
 * See: https://www.gatsbyjs.org/docs/gatsby-config/
 */

module.exports = {
  plugins: [
    {
      resolve: `gatsby-source-filesystem`,
      options: {
        name: `images`,
        path: `${__dirname}/static`,
      },
    },
    'gatsby-transformer-sharp',
    'gatsby-plugin-sharp',
    {
      resolve: "gatsby-source-graphql",
      options: {
        typeName: "WwdmGraph",
        fieldName: "wwdm",
        url: "http://localhost:5001/graphql/",
      },
    },
    /*{
      resolve: `gatsby-plugin-remote-images`,
      options: {
        nodeType: 'WwdmGraph_Image',
        imagePath: 'id',
        prepareUrl: url => 'http://localhost:5002/images/' + url
      },
    },*/
  ],
}
