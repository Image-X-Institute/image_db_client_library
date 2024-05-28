# Data Organisation Structure in VCU

This document provides an overall structure of the files located on the clinical trials data shared drive relevant to VCU Trial. The following lists the overall procedure level as well individual fraction level details. However, for all the path options, please refer to the site descriptor JSON file.

## Fraction Specific Data

Depending upon the number of fractions of treatment for every patient, the following data is contained in seperate fraction level folders.

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| respiratory_files_path | [Description] | VCU_P4/VCU/Derived/Trimmed RPM Data/{centre_patient_no}/{rpm_files_path} | |
| trajectory_logs | [Description] | VCU_P4/VCU/Raw/Trajectory Logs/Pat{centre_patient_no:02d}[ ,-]*{patient_trial_id}/{fraction_name};SPARK/CMN/Trajectory Logs/Pat{centre_patient_no:02d}[ ,-]*{patient_trial_id}/Fx{fraction_number:02d} | |
| kim_logs | [Description] | VCU_P4/VCU/Raw/Patient Measured Motion/CMN_PAT{centre_patient_no:02d}/CMN_PAT{centre_patient_no:02d}_{fraction_name} | |
| DVH_track_path | [Description] | VCU_P4/VCU/Raw/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/PAT{centre_patient_no:02d}[_]*Fx0{fraction_number}[_]*Track.txt | |
| DVH_no_track_path | [Description] | VCU_P4/VCU/Raw/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/PAT{centre_patient_no:02d}[_]*Fx0{fraction_number}[_]*NoTrack.txt | |
| DICOM_no_track_plan_path | [Description] | VCU_P4/VCU/Raw/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/Fx0{fraction_number}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]no[a-z,_]*.dcm | |
| DICOM_track_plan_path | [Description] | VCU_P4/VCU/Raw/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/Fx0{fraction_number}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]track[a-z,_]*.dcm | |
| KV_images | [Description] | VCU_P4/VCU/Raw/{centre_patient_no}/{fraction_name}/Projections | |
| MV_images | [Description] | VCU_P4/VCU/Raw/{centre_patient_no}/{fraction_name}/KIM-MV | |
| metrics | [Description] | VCU_P4/VCU/Raw/Triangulation/Patient {centre_patient_no}/{fraction_name}/'Metrics.xls;SPARK/CMN/Patient Images/Patient {centre_patient_no}/{fraction_name}/Triangulation/'Metrics.xls;SPARK/CMN/Patient Images/Patient {centre_patient_no}/Triangulation/{fraction_name}/'Metrics.xls | |
| triangulated_pos | [Description] | N/A | |
