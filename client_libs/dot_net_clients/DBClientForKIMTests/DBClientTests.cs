using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ImagingDBClientLibrary;

namespace DBClientForKIMTests
{
    class DBClientTests
    {
        // private DBClient client = new DBClient("http://localhost:8090");
        private DBClient client = new DBClient("http://data-service-dev.ap-southeast-2.elasticbeanstalk.com");

        public DBClientTests()
        {
            //client
        }

        private bool testAuthenticate()
        {
            return client.makeAuthRequest("C:\\Indrajit\\git_repos\\realtime_imaging_db\\initial_repo\\data_service\\tests\\sample_tokenfile.txt", "");
        }

        private void dumpFileContentsToConsole(string filePath, string queryLevel)
        {
            System.Console.WriteLine("Result file with {0} seems to exist: {1}", queryLevel, filePath);
            string[] fileContent = File.ReadAllLines(filePath);
            int counter = 0;
            System.Console.WriteLine("-------------------------------------------------------------");
            foreach (string line in fileContent)
            {
                System.Console.WriteLine("{0}: {1}", counter++, line);
            }
            System.Console.WriteLine("-------------------------------------------------------------");
        }
        private bool testGetPatientDetails()
        {
            string resultsFilePath = client.getPatientDetails("1501001");
            if (File.Exists(resultsFilePath))
            {
                dumpFileContentsToConsole(resultsFilePath, "patient query");
                return true;
            }
            return false;
        }

        private bool testGetAllFractionDetails()
        {
            string resultsFilePath = client.getAllAvailableFractions();
            if (File.Exists(resultsFilePath))
            {
                dumpFileContentsToConsole(resultsFilePath, "all fractions query");
                return true;
            }
            return false;
        }

        private bool testContentDownload()
        {
            string resultsFilePath = client.makeContentRequest("/SPARK/CMN/Patient Files/Patient 1/1501001_Centroid.txt");
            if (File.Exists(resultsFilePath))
            {
                dumpFileContentsToConsole(resultsFilePath, "downloaded file");
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            DBClientTests tests = new DBClientTests();
            if (tests.testAuthenticate())
                System.Console.WriteLine("Authentication test successful");
            else
                System.Console.WriteLine("Authentication Failed");

            if (tests.testGetPatientDetails())
                System.Console.WriteLine("Patient query successful");
            else
                System.Console.WriteLine("Patient query Failed");

            if (tests.testGetAllFractionDetails())
                System.Console.WriteLine("all fractions query successful");
            else
                System.Console.WriteLine("all fractions query Failed");

            if (tests.testContentDownload())
                System.Console.WriteLine("content download successful");
            else
                System.Console.WriteLine("content download Failed");

            System.Console.Write("Press any key to terminate...");
            System.Console.ReadKey();

        }
    }
}
