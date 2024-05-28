using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;


namespace ImagingDBClientLibrary
{
    public class DBClient
    {
        private bool debugMode = true;  // enable to print lots of debug info on the console
        private static readonly WebClient client = new WebClient();
        private string baseUrl = "http://localhost:8090/";
        private string sessionToken = null;
        private string cacheDirPath;
        private bool removeResponseFilesAtFinalise = true;

        public DBClient(string baseUrl, bool removeResponseFilesAtFinalise=true)
        {
            this.baseUrl = baseUrl;
            client.Headers.Add("User-Agent", "Image X Real time DB .NET client");
            Trace.Listeners.Add(new TextWriterTraceListener("ImagingDBClient.log"));
            cacheDirPath = GetCacheFolderPath ();
            if (debugMode)
                System.Console.WriteLine("Using {0} for temporary cache path", cacheDirPath);
            this.removeResponseFilesAtFinalise = removeResponseFilesAtFinalise;
        }

        ~DBClient()
        {
            if (removeResponseFilesAtFinalise)
                clearCache();
        }

        private Dictionary<string, string> parseSingleLevelJSON(string json)
        {
            Dictionary<string, string> parsedOutput = new Dictionary<string, string>();
            int startingBraceIndex = json.IndexOf('{');
            int endingBraceIndex = json.LastIndexOf('}');
            string keyValueString = json.Substring(startingBraceIndex + 1,
                                                    endingBraceIndex - (startingBraceIndex + 1));

            string[] keyValues = keyValueString.Split(',');
            foreach (string kv in keyValues)
            {
                string trimmedKv = kv.Trim();
                string[] keyValuePair = trimmedKv.Split(':');

                if (keyValuePair.Length != 2)
                    continue; // malformed JSON?

                string key = keyValuePair[0].Trim();
                key = key.Trim('\"');
                string value = keyValuePair[1].Trim();
                value = value.Trim('\"');

                if (value.StartsWith("{"))
                    continue;  // ignore nested data

                parsedOutput.Add(key, value);
            }

            return parsedOutput;
        }

        private string GetCacheFolderPath()
        {
            /// Credit: https://stackoverflow.com/questions/278439/creating-a-temporary-directory-in-windows

            string tempDirPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirPath);
            return tempDirPath;
        }

        private void RecursivelyDeleteDir(string path)
        {
            /// Credit: https://stackoverflow.com/questions/5092611/delete-folder-files-and-subfolder

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            
            if (!dirInfo.Exists)
                return;

            foreach (FileInfo file in dirInfo.GetFiles())
                file.Delete();

            foreach (DirectoryInfo subdir in dirInfo.GetDirectories())
                RecursivelyDeleteDir(subdir.FullName);
            
            dirInfo.Delete();
        }

        public bool makeAuthRequest(string tokenPath, string secret)
        {
            string encodedToken = "";

            try
            {
                encodedToken = File.ReadAllText(tokenPath);
            } 
            catch (DirectoryNotFoundException dirEx)
            {
                if (debugMode)
                    System.Console.WriteLine("Could not find the token file for authentication " + dirEx.ToString());
                Trace.TraceError("Could not find the token file for authentication " + dirEx.ToString());
                return false;
            }

            if (null == client.Headers.Get("token"))
                client.Headers.Add("token", encodedToken);
            else
                client.Headers.Set("token", encodedToken);

            if (null == client.Headers.Get("token"))
                client.Headers.Add("secret", secret);

            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

            bool authResult = false;
            string serverResponse = client.UploadString(baseUrl + "/auth", "");
            if (serverResponse.Contains("token"))
            {
                Dictionary<string, string> responseDict = parseSingleLevelJSON (serverResponse);
                this.sessionToken = responseDict["token"];
                authResult = true;
            }
            else
            {
                if (debugMode)
                    System.Console.WriteLine("Authentication failed. Server responed with: {0}", serverResponse);
                Trace.TraceWarning("Server authentication failure");
            }

            client.Headers.Remove("secret");
            client.Headers["token"] = sessionToken;

            return authResult;
        }

        public void clearCache()
        {
            RecursivelyDeleteDir(cacheDirPath);
        }

        public string getPatientDetails(string patientTrialId)
        {
            string patientDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/patients?patient_trial_id=" + patientTrialId + "&format=csv";
            client.DownloadFile (queryPath, patientDetailsCsvPath);
            return patientDetailsCsvPath;
        }

        public string getPatientDetails(string trial, string treatementCentre, int patientSequence)
        {
            string patientDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/patients?trial=" + trial 
                                        + "&centre=" + treatementCentre
                                        + "&patient=" + patientSequence.ToString()
                                        + "&format=csv";
            client.DownloadFile(queryPath, patientDetailsCsvPath);
            return patientDetailsCsvPath;
        }

        public string getAllAvailablePatients()
        {
            string patientDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/patients?format=csv";
            client.DownloadFile(queryPath, patientDetailsCsvPath);
            return patientDetailsCsvPath;
        }

        public string getPrescriptionDetailsForPatient(string patientTrialId)
        {
            string prescriptionDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/prescriptions?patient_trial_id=" + patientTrialId + "&format=csv";
            client.DownloadFile(queryPath, prescriptionDetailsCsvPath);
            return prescriptionDetailsCsvPath;
        }

        public string getPrescriptionDetailsForPatient(string trial, string treatementCentre, int patientSequence)
        {
            string prescriptionDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/prescriptions?trial=" + trial
                                        + "&centre=" + treatementCentre
                                        + "&patient=" + patientSequence.ToString()
                                        + "&format=csv";

            client.DownloadFile(queryPath, prescriptionDetailsCsvPath);
            return prescriptionDetailsCsvPath;
        }

        public string getAllAvailablePrescriptions()
        {
            string prescriptionDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/prescriptions?format=csv";
            client.DownloadFile(queryPath, prescriptionDetailsCsvPath);
            return prescriptionDetailsCsvPath;
        }


        public string getFractionDetailsForPatient(string patientTrialId)
        {
            string fractionDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/fractions?patient_trial_id=" + patientTrialId + "&format=csv";
            client.DownloadFile(queryPath, fractionDetailsCsvPath);
            return fractionDetailsCsvPath;
        }

        public string getFractionDetailsForPatient(string trial, string treatementCentre, int patientSequence)
        {
            string fractionDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/fractions?trial=" + trial
                                        + "&centre=" + treatementCentre
                                        + "&patient=" + patientSequence.ToString()
                                        + "&format=csv";
            client.DownloadFile(queryPath, fractionDetailsCsvPath);
            return fractionDetailsCsvPath;
        }


        public string getAllAvailableFractions()
        {
            string fractionDetailsCsvPath = Path.Combine(cacheDirPath, Path.GetRandomFileName()) + ".csv";
            string queryPath = baseUrl + "/fractions?format=csv";
            client.DownloadFile(queryPath, fractionDetailsCsvPath);
            return fractionDetailsCsvPath;
        }

        public string makeContentRequest(string path, bool isRelative=true)
        {
            string downloadedContentPath = Path.Combine(cacheDirPath, Path.GetRandomFileName());

            if (path.StartsWith("/"))
                path = path.Substring(1, path.Length - 1);
            string queryPath = baseUrl + "/content/" + path;

            if (!isRelative)
            {
                queryPath = path;  // the calling code is sending a proper URL instead of a relative path
            }

            queryPath.Replace(" ", "%20");

            byte[] data = client.DownloadData(queryPath);

            if (null != client.ResponseHeaders.Get("Content-Disposition"))
            {
                string[] disposition = client.ResponseHeaders["Content-Disposition"].Split("filename=".ToCharArray());
                if (disposition.Length > 1)
                {
                    downloadedContentPath = downloadedContentPath + "_" + disposition[1];
                }
                File.WriteAllBytes(downloadedContentPath, data);
            }
            else
            {
                downloadedContentPath = downloadedContentPath + "_dirListing.json";
                File.WriteAllBytes(downloadedContentPath, data);
            }
            return downloadedContentPath;
        }

        public bool uploadContent(string[] files, Dictionary<string, string> additionalData)
        {
            // Not yet implemented
            return false;
        }
    }
}
