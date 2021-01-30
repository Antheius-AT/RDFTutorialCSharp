# RDFTutorialCSharp
This is an RDF tutorial written in C# using the RDF sharp library.

## RDF Dll

### Triple Store
The triple store can be considered the main application class, as it holds a reference to the database service, and offers methods to execute data manipulation
as well as queries on the database. In its constructor a database service object is injected, allowing the triple store to access the database, without 
needing to know implementation specific details. Thus, the choice of which database to use for storage is left to the developer choosing to implement this RDF dll.
The Triple Store itself currently offers three methods for working with the underlying data. The implemented methods are:
* ```public async Task<bool> TryAddTripleAsync(Triple triple)```
* ```public async Task<bool> TryDeleteTripleAsync(Triple triple)```
* ```public async Task<IEnumerable<Triple>> RetrieveMatchingTriplesAsync(string subject, string predicate, string @object)```


In the last part of this section, I want to talk about those methods in detail.

#### ```public async Task<bool> TryAddTripleAsync(Triple triple)```
This method can be used to add a triple to the database. Thus to properly execute this method requires you to specify
an object of type RDFTutorialLogic.Data.Triple, containing a subject, predicate as well as object.

If, for whatever reason, you pass a null reference to the method, an exception of type System.ArgumentNullException will be thrown.
Otherwise this method is safe, thus using try-catch while invoking this method is not necessary.

The TryAddTripleAsync method is implemented asynchronously, meaning it will return a task (which you can choose to await), handling the logic of adding the specified triple to the database,
and containing a boolean in its result on termination. The resulting boolean indicates whether the operation was successful, and the triple was added into the database.

#### ```public async Task<bool> TryDeleteTripleAsync(Triple triple)```
This method can be used to remove a triple from the database. To properly invoke this method, you are required to specify
a triple object which you want to delete. The deleted triple object and the stored triple object are **not** required to be equal in reference,
so long as they match each other in subject, predicate as well as object, they will be regarded as being the same. Thus, if you add a triple X
by invoking the add method, then proceed to create a new triple Y holding the exact same values, and then proceed to call this method passing the triple Y
as parameter, the triple X will be successfully deleted.

Exception wise this method is safe, meaning even if you specify a triple that does not exist in the database, and thus can not be deleted, the method won't throw an exception.

If however for some reason you pass a null reference to the method, an exception of type System.ArgumentNullException will be thrown.

This method, like all of the other methods in this class, is implemented in an async fashion, meaning it returns a task which you can await if you so choose, handling the logic of deleting the triple.
The returned task contains a boolean in its result on termination, indicating whether the triple was successfully deleted.

#### ```public async Task<IEnumerable<Triple>> RetrieveMatchingTriplesAsync(string subject, string predicate, string @object)```
This method can be used to retrieve all triples matching one or more of the specified subject, predicate, or object.
To successfully invoke this method, you are required to specify three strings, being mapped to subject, predicate and object respectively.

Any triples matching the specified subject, predicate or object will be fetched from the database and returned.

For this method you are allowed to specify both null, and *.
The * operator serves as a wildcard, matching all possible values.
Specifying null works as specifying any regular string would, matching triples that have "null" stored in the respective field.

If you attempt to call this method specifying an empty string, it will throw an exception. Use either * or null instead of an empty string, regarding on what you are trying to achieve.

This method, being async, returns a task object handling the logic, which is awaitable.
On termination the task returns a System.Collections.Generic.IEnumerable<Triple> object, containing all of the matching triples.

### Triple Parser
The Triple Parser class offers a single method to parse triples from objects of type RDFTutorialLogic.Data.RawTripleData, which is returned when using the Data Reader class
for reading triple data from an external source.

The single method for parsing triples is:
* public Triple Parse(RawTripleData data)

This method may throw two kinds of exceptions:
* System.ArgumentNullException is thrown if you pass a null reference as an argument while invoking the method.
* REDFTutorialLogic.Exceptions.TripleParsingFailedException is thrown if the parsing of the specified data failed. 

Given the nature of triples and the fact that no validation apart from whether or not actual data is specified needs to happen, the TripleParsingFailedException is only thrown,
if the Data property of the RDFTutorialLogic.Data.RawTripleData type, which we will explain in the next section, does not contain exactly three string objects.

If you are able to ensure that the RawTripleData object you pass as an argument to this method, does in fact contain exactly three strings in its Data property, you are not required
to specify a try-catch clause.

This class implements the ***RDFTutorialLogic.Interfaces.ITripleParser*** interface.
This means, that if you want to specify your own triple parser and choose to not use the triple parser being implemented by default, you are able to implement this interface, write your own implementation,
and use that implementation instead.

### Raw Triple Data
The Raw Triple Data represents some data that has been read from an external source, however has yet to be parsed into an actual Triple.
It contains one member, being a System.IEnumerable<string> property called Data. 
When using the DataReader class to read data from an external source, one or more objects of this type are returned.

The Triple Parser class, which was talked about in the previous section, is able to parse raw data into concrete objects of type triple.

While a triple is an object specified in the format Subject-Predicate-Object, any object of type RawTripleData may have more or less elements stored in its
Data property. 
This is due to the fact, that from the applications point of view, the RawTripleData has not yet been confirmed as being a triple, thus the RawTripleData is not required to
follow the known triple format. 
However, be aware that trying to parse raw triple data into a Triple object using the aforementioned TripleParser, will lead to an exception being thrown.

### Database Service
TODO

### Data Reader
This component is responsible for reading data from a specified file. This version of the RDF Sharp library only supports csv files.

### Distribution

Components Gregor: 
* Raw Triple Data (done)
* Parser (done)
* Database Service
* Triple store

Components Tom:
* Triple (done)
* DataReader 
* Database Service
