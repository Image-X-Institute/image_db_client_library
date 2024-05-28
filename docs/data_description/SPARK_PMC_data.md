# Data Organisation Structure in PMC for SPARK Trial

This document provides an overall structure of the files located on the clinical trials data shared drive relevant to SPARK Trial conducted in PMC centre. The following lists the overall procedure level as well individual fraction level details. However, for all the path options, please refer to the site descriptor JSON file.

## Patient Procedure Level Data

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| RT_structure_path | [Description] | SPARK/PMC/Dose Reconstruction/Dose/PAT{centre_patient_no:02d}/Original Plan/RS[.,0-9,_,a-z]*.dcm;SPARK/PMC/Patient Plans/{patient_trial_id}/{patient_trial_id}/RS[_,0-9]*{patient_trial_id}_DEIDENT_[0-9]*.dcm | |
| RT_plan_path | [Description] | SPARK/PMC/Dose Reconstruction/Dose/PAT{centre_patient_no:02d}/Original Plan/RP[.,0-9,_,a-z]*.dcm;SPARK/PMC/Patient Plans/{patient_trial_id}/{patient_trial_id}/RP[_,0-9]*{patient_trial_id}_DEIDENT_[0-9]*.dcm | |
| RT_CT_path | [Description] | SPARK/PMC/Patient Plans/{patient_trial_id}::containing CT[0-9,_,a-z]*.dcm | |
| RT_MRI_path | [Description] | SPARK/PMC/Patient Plans/{patient_trial_id}/{patient_trial_id}::containing MR[0-9,_,a-z]*.dcm;SPARK/PMC/Patient Plans/{patient_trial_id}/^[0-9,_,-]*$::containing MR[0-9,_,a-z]*.dcm | |
| RT_dose_path | [Description] | SPARK/PMC/Dose Reconstruction/Dose/PAT{centre_patient_no:02d}/Original Plan/RD[.,0-9,_,a-z,A-Z]*.dcm | |
| RT_DVH_original_path | [Description] | SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/[A-Z,a-z,0-9,_]*Original[A-Z,a-z,_]*.txt | |
| RT_DVH_summed_no_track_path | [Description] | SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/NoTracking_PlanSum.txt;SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/PlanSum[_]*NoTracking.txt;SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/[_,0-9,a-z]*NoTrackingSum.txt | |
| RT_DVH_summed_track_path | [Description] | SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/Tracking_PlanSum.txt;SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/PlanSum[_]*Tracking.txt;SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/[_,0-9,a-z]*TrackingSum.txt | |
| centroid_path | [Description] | SPARK/PMC/Patient Files/PAT{centre_patient_no:02d} - {patient_trial_id}/Centroid.txt | |

## Fraction Specific Data

Depending upon the number of fractions of treatment for every patient (usually 5), the following data is contained in seperate fraction level folders.

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| trajectory_logs | [Description] | SPARK/PMC/Trajectory Logs/PAT{centre_patient_no:02d}[ ,-]*{patient_trial_id}/{fraction_name};SPARK/PMC/Trajectory Logs/Pat{centre_patient_no:02d}[ ,-]*{patient_trial_id}/Fx{fraction_number:02d} | |
| kim_logs | [Description] | SPARK/PMC/Patient Measured Motion/PMC_PAT{centre_patient_no:02d} - {patient_trial_id}/PMC_PAT{centre_patient_no:02d}[-,_, ]*{patient_trial_id}_{fraction_name} | |
| DVH_track_path | [Description] | SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/[0-9,a-z,_]*Fx0{fraction_number}[_]*Tracking.txt | |
| DVH_no_track_path | [Description] | SPARK/PMC/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/[0-9,a-z,_]*Fx0{fraction_number}[_]*No[_, ]*Tracking.txt | |
| DICOM_no_track_plan_path | [Description] | SPARK/PMC/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/Fx0{fraction_number}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]no[a-z,_]*.dcm;SPARK/PMC/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]no[_,a-z]*.dcm;SPARK/PMC/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]woKIM.dcm | |
| DICOM_track_plan_path | [Description] | SPARK/PMC/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/Fx0{fraction_number}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]track[a-z,_]*.dcm;SPARK/PMC/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]track[a-z]*.dcm;SPARK/PMC/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]wKIM.dcm | |
| KV_images | [Description] | SPARK/PMC/Patient Images/PAT{centre_patient_no:02d} - {patient_trial_id}/{fraction_name}/[a-z,0-9,_]*/KIM-KV;SPARK/PMC/Patient Images/PAT{centre_patient_no:02d} - {patient_trial_id}/{fraction_name}/[a-z,0-9,_]*/[a-z,0-9,_]*/KIM-KV | |
| MV_images | [Description] | SPARK/PMC/Patient Images/PAT{centre_patient_no:02d} - {patient_trial_id}/{fraction_name}/[a-z,0-9,_]*/KIM-MV;SPARK/PMC/Patient Images/PAT{centre_patient_no:02d} - {patient_trial_id}/{fraction_name}/[a-z,0-9,_]*/[a-z,0-9,_]*/KIM-MV | |
| metrics | [Description] | SPARK/PMC/Triangulation/PAT{centre_patient_no:02d}/{fraction_name}/'Metrics.xls | |
| triangulated_pos | [Description] | SPARK/PMC/Triangulation/PAT{centre_patient_no:02d}/{fraction_name}/'TriangulatedPositions.xls | |
