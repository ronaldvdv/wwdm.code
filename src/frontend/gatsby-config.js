/**
 * Configure your Gatsby site with this file.
 *
 * See: https://www.gatsbyjs.org/docs/gatsby-config/
 */

module.exports = {
  plugins: [
    'gatsby-transformer-sharp',
    'gatsby-plugin-sharp',
    {
      resolve: "gatsby-source-graphql",
      options: {
        typeName: "WwdmGraph",
        fieldName: "wwdm",
        url: "http://localhost:61177/graphql/",
      },
    },
    {
      resolve: `gatsby-plugin-remote-images`,
      options: {
        nodeType: 'WwdmGraph_Image',
        imagePath: 'filename',
        prepareUrl: url => '../../data/private/shots/' + url
      },
    },
  ],
}
