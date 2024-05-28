# Real-Time Imaging Database Python Client Manual

The Real-Time Imaging Database (database) provides the facility to query the imported data using RESTful APIs. However, to use these APIs, it is necessary to be authenticated with the database service and make a HTTP based request and process the JSON/CSV responses. To makes this easier, several client libraries and modules have been developed to support several languages and platforms. This document explains how to use the Python client module to query the database and use the results.

## Introduction

The database client python library has been developed for use with Python 3.x and uses the [requests](https://docs.python-requests.org/en/latest/) library to communicate with the database. It has been developed into a package for use with python packaging and deployment tools.

## Installation

The client library needs to be installed for use within the python environment of choice. This can be done using the pip utility using the following commands:

```bash
python3 -m pip install <path of local repo>/python_clients/ImagingDBClient
```

Remember to set the appropriate python environment (using `conda activate` or `source venv/bin/activate`) before installing this library to ensure that it is accessible.

To use the library, it should be imported into the python script:

```python
from ImagingDBClient import Clients
```

## Connecting With the Database

To connect to the database, the database client needs to be instantiated with the URL for the database server. 

```python
dbClient = Clients.ImagingDBClient(baseUrl=”https://server:port”)

```

Optionally, a path for receiving the downloaded content may be passed to the `ImagingDBClient` constructor to allow it to use the provided path as the download folder using the `downloadPath` parameter. If this parameter is not specified, then the library would create and use a temporary folder (in the OS temporary files path).

### Authentication

By default, the database service expects the end user to authenticate before making any requests (the exception maybe a development server instance, which may work without any authentication). This is managed by using a preassigned token file as well as a password. The client library’s `makeAuthRequest` method can be used to authenticate with the database by passing the content of the token file and a dictionary of additional parameters containing the password referenced with the string key `password`.

```python

# read the authentication token from the token file
with open(self.tokenFilePath) as tokenFile:
    tokenStr = tokenFile.readline()

# take the password from the user
secret = “”

dbClient.makeAuthRequest(tokenStr, additionalParams={“password”:secret})

```

## Querying Details

To obtain the patient, prescription or fraction level details from the database, the corresponding query function can be called by providing it with a patient identifier (this is not the same as the actual patient ID and is usually assigned by TROG or a similar authority).

The query methods return a dictionary constructed from the JSON response containing the same key value pairs described in the API documentation of the database instance (available by querying the `apidoc` endpoint or the server, for example: `https://databaseserver/apidoc`). 

```python
# get patient level details:
patientLevelData = dbClient.getPatientDetails(patientTrialId=”<patient ID>”)

# get prescription level details:
patientLevelData = dbClient.getPrescriptionDetailsForPatient(patientTrialId=”<patient ID>”)

# get fraction level details:
patientLevelData = dbClient.getFractionDetailsForPatient(patientTrialId=”<patient ID>”)

```

## Downloading Content from the Database

The database allows downloading the actual file contents referred to in the data fields by using the `makeContentRequest` method and passing the URL of the file. He URL would typically use the `content` endpoint of the server followed by the path of the resource from the query response for a patient. The method returns a `tuple` that contains three elements: a status code, a MIME type and the actual content. This is summerised by the following table:

| Status Code | MIME Type | Content |
| --- | --- | --- |
| RESPONSE_TYPE_ERR | `application/json` | A JSON sting describing the error that occurred while requesting for the content. It is usual for a key named `message` to be present with a human friendly error message |
| RESPONSE_TYPE_LISTING | `application/json` | In case the path represents a folder (such as KV images folder) then the listing of the files under it are provided in JSON format |
| RESPONSE_TYPE_FILE | appropriate MIME type | The downloaded file path |

The actual mechanism to download the file is demonstrated by the snippet below:

```python

file_url = “https://databaseserver:port/content/trial/site/...”
resp = dbClient.makeContentRequest(file_url)

if resp[0] == dbClient.RESPONSE_TYPE_FILE:
    # open the file from resp[2] 

```

## Uploading Content to the Database

To upload a file to the database, the method `uploadContent` should be called with the path of the file to be uloaded and additional metadata. The additional metadata allows the file to be associated with the appropriate patient, fraction etc. and also specify the type of the file.

```python
    metadata = {
        "test_centre": 'CMN',
        "patient_trial_id": '1001',
        "centre_patient_no": '1',
        "level": 'fraction',
        "file_type": 'CT series',
        "fraction": 'Fx01',
        "clinical_trial": 'SPARK'
    }

    result = dbClient.uploadContent(files, metadata)
    if result:
        print("upload accepted")
```
