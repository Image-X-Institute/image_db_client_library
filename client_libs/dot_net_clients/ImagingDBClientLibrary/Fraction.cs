using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;


namespace ImagingDBClientLibrary
{
    public class Fractions
    {
        [JsonPropertyName("fractions")]
        public Fraction[] fractions { get; set; }

    }

    public class Fraction
    {
        [JsonPropertyName("patient_trial_id")]
        public string patientTrialId { get; set; }

        [JsonPropertyName("test_centre")]
        public string testCentre { get; set; }

        [JsonPropertyName("patient_no")]
        public int patientNumber { get; set; }

        [JsonPropertyName("fraction_no")]
        public int fractionNumber { get; set; }

        [JsonPropertyName("fraction_name")]
        public string fractionName { get; set; }

        [JsonPropertyName("date")]
        public string fractionDate { get; set; }

        [JsonPropertyName("gating_events")]
        public int numberGatingEvents { get; set; }

        [JsonPropertyName("kim_logs")]
        public string kimLogsPath { get; set; }

        [JsonPropertyName("kv_images")]
        public string kvImagesPath { get; set; }

        [JsonPropertyName("mv_images")]
        public string mvImagesPath { get; set; }

        [JsonPropertyName("metrics")]
        public string metricsFilePath { get; set; }

        [JsonPropertyName("triangulation")]
        public string triangulationFilePath { get; set; }

        [JsonPropertyName("trajectory_logs")]
        public string trajectoryLogsPath { get; set; }

        [JsonPropertyName("DVH_track_path")]
        public string trackedDVHFilePath { get; set; }

        [JsonPropertyName("DVH_no_track_path")]
        public string notTrackedDVHFilePath { get; set; }

        [JsonPropertyName("DICOM_track_plan_path")]
        public string trackedDICOMPlanFilePath { get; set; }

        [JsonPropertyName("DICOM_no_track_plan_path")]
        public string notTrackedDICOMPlanFilePath { get; set; }
    }
}
