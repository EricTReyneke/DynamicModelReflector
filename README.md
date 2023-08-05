# DynamicModelReflector
Creating a data access layer that follows SOLID principles and Dependency injection. 

--Problem Statement:
Develop a data access layer, akin to the Entity Framework, where queries are generated and populated with data received from the database into 
the provided Plain Old CLR Objects (POCO) classes.

The current approach to solving this problem might lead to a cluttered solution, and query construction could potentially become inefficient. 
There may be additional challenges due to the omission of the SqlCommand class, particularly when it comes to validating data types for null and non-null values.

The initial goal for this project is to bring it to a fully functional state, with the DataModelReflector possessing Load, Create, Delete, and Update 
(CRUD) functionality.

Once this objective is fulfilled, the aim is to start a new project addressing the same issue, but this time utilizing the Expression Visitor class to write
functions that can leverage LINQ. I haven't delved deeply into the specifics of the Expression Visitor class yet, but I suspect it might streamline the code.
However, this could also introduce a host of complexities.
