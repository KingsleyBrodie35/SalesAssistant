# Landscaping SalesAssistant
Landscaping SalesAssistant is a console based tool that helps users in finding Landscaping products by asking professional sales questions to return products
in a persistant data store based on the responses by the user.

The tool utilizes a family of command classes to determine which type of product the customer is after (paver or retaining wall) and the series of commands (questions) to provide in the console that are specifc to the type of product the customer has selected.

![image](https://user-images.githubusercontent.com/129143660/229258573-5f9584b0-d913-4599-97b1-16e8460573c3.png)

Once we have determined the type of product the customer is after we run an SQL statement to return products based on input given such as colour, size, etc.
The customer can select a product and create an order, the tool will ask for sqaure meatures and return the amount of pavers or blocks required and a price, the customer can add multiple products to the order.

![image](https://user-images.githubusercontent.com/129143660/229258936-9f6227cb-65e4-4312-8d8d-2b4ca6c4eef0.png)

The project utilises C#, .NET development and MySQL
