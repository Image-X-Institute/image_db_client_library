# Imaging DB Client for Applications using .NET version 2.0 ~ 4.5

This folder contains the class library project for use with applications that do not have the proper HTTP and JSON handing frameworks in place for querying the RESTful services. It uses the older WebClient API and queries for  responses in CSV format instead of JSON, which it saves as a temporary file and returns the path to the calling code.

# Usage

To use the library, and instance of the `ImagingDBClientLibrary.DBClient` class should be created after adding the dll as a project reference and instantiated with the base URL of the service. For example, if the service is running on `data-service-dev.ap-southeast-2.elasticbeanstalk.com` then it should be initialised as follows:

```csharp
using ImagingDBClientLibrary;

DBClient client = new DBClient ("http://data-service-dev.ap-southeast-2.elasticbeanstalk.com");
```

The second argument to the constructor is optional and can be set to `false` if the calling code wants to use the returned file paths even after the `DBClient` instance has gone out of scope (and hence has removed the temporary files created by it).

## Querying Using API Endpoints

If authentication is enabled for the database service (it may not be enabled only for development instances), then the authetication token should be used at the outset:

```csharp
client.makeAuthRequest ("<path to token file>", "<password>");
```

This library can be used to query the DB at patient, prescription and fraction (which includes images) levels. For each level, individual methods to query the database for all the available objects, objects matching the patient trial ID (such as TROG id `1501011`) and objects matching the trial, treatment centre and patient sequence are available.

```csharp

// fraction level querying: the results are available as a CSV file

// Case 1: Query for all fractions available to the user
string resultsFilePath = client.getAllAvailableFractions();

// Case 2: Query for fractons of a specific patient by the TROG ID
string patientTrialId = "1501001";
string resultsFilePath = client.getFractionDetailsForPatient(patientTrialId);

// Case 3: Query for fractions of a patient by the patient sequence of treatment
string resultsFilePath = client.getFractionDetailsForPatient("SPARK", "CMN", 1)

```

Similarly named methods are available, as shown above, for querying at prescription and patient levels.

## Getting Access to the Physical Files

To access the actual file paths contained in the fraction/prescription objects, the following method can be used:

```csharp
string downloadedFilePath = client.makeContentRequest("/SPARK/CMN/Patient Files/Patient 1/1501001_Centroid.txt");
```
The above method would download the requested file (using HTTP) to a temporary location on the local system and return its path. In case the path being queried belongs to a folder (instead of an actual file), the directory listing details are saved and returned, which needs to be parsed by the calling code. Similarly, in case there is an issue with accessing the file/folder (such as incorrect path or limited access with the token used), the error is saved as a JSON file and the calling application should parse it to handle the error.
