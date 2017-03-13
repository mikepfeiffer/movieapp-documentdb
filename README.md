# MovieApp with DocumentDB
This sample application allows users to create, read, update, and delete a list of Movies. Movie items are saved as JSON documents in Azure DocumentDB.

To use this code do the following:
* Create a DocumentDB account in the Azure portal
* Update the "endpoint" key in the web.config to use the URI of the DocumentDB account. This value can be found under the "Keys" blade within the DocumentDB account in the portal.
* Update the "authKey" in the web.config to use the primary or secondary key of the DocumentDB account. This value can be found under the "Keys" blade within the DocumentDB account in the portal.
* Run the application and test
