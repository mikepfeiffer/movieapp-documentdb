# MovieApp with DocumentDB API
This sample ASP.NET MVC 5 application allows users to create, read, update, and delete a list of Movies. Movie items are saved as JSON documents in Azure Cosmos DB using the DocumentDB API.

To use this code do the following:
* Create a Cosmos DB account using the DocumentDB API in the Azure portal
* Create a collection called Movie in a database called MovieApp and set the partition key to Rating
* Update the "endpoint" key in the web.config to use the URI of the Cosmos DB account. This value can be found under the "Keys" blade within the DocumentDB account in the portal.
* Update the "authKey" in the web.config to use the primary or secondary key of the DocumentDB account. This value can be found under the "Keys" blade within the Cosmos DB account in the portal.
* Run the application and test
