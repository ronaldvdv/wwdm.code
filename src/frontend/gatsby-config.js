/**
 * Configure your Gatsby site with this file.
 *
 * See: https://www.gatsbyjs.org/docs/gatsby-config/
 */

module.exports = {
  plugins: [
    {
      resolve: "gatsby-source-graphql",
      options: {
        typeName: "WwdmGraph",
        fieldName: "wwdm",
        url: "http://localhost:61177/graphql/",
      },
    }
  ],
}
