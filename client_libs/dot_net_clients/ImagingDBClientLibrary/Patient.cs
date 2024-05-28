using System;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ImagingDBClientLibrary
{
    public class Patients
    {
        [JsonPropertyName("patients")]
        public Patient[] patients { get; set; }
    }

    public class Patient
    {
        [JsonPropertyName("age")]
        public int age { get; set; }

        [JsonPropertyName("gender")]
        public string gender { get; set; }

        [JsonPropertyName("clinical_diagnosis")]
        public string clinicalDiagnosis { get; set; }

        [JsonPropertyName("trial")]
        public string clinicalTrial { get; set; }

        [JsonPropertyName("patient_trial_id")]
        public string patientTrialId { get; set; }

        [JsonPropertyName("test_centre")]
        public string testCentre { get; set; }

        [JsonPropertyName("tumour_site")]
        public string tumourSite { get; set; }

    }
}