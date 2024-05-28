# Data Organisation Structure in Westmead for SPARK Trial

This document provides an overall structure of the files located on the clinical trials data shared drive relevant to SPARK Trial conducted in Westmead centre. The following lists the overall procedure level as well individual fraction level details. However, for all the path options, please refer to the site descriptor JSON file.

## Patient Procedure Level Data

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| RT_structure_path | [Description] | SPARK/Westmead/Dose Reconstruction/Dose/PAT{centre_patient_no:02d}/Original Plan/RS[.,0-9,_,a-z]*.dcm;SPARK/Westmead/Patient Plans/{patient_trial_id}/{patient_trial_id}/RS[_,0-9]*{patient_trial_id}_DEIDENT_[0-9]*.dcm | |
| RT_plan_path | [Description] | SPARK/Westmead/Dose Reconstruction/Dose/PAT{centre_patient_no:02d}/Original Plan/RP[.,0-9,_,a-z]*.dcm;SPARK/Westmead/Patient Plans/{patient_trial_id}/{patient_trial_id}/RP[_,0-9]*{patient_trial_id}_DEIDENT_[0-9]*.dcm | |
| RT_CT_path | [Description] | SPARK/Westmead/Patient Pre RT from TROG/WM {patient_trial_id}/(?:review|diagnostic)/trial/15.01/{patient_trial_id}/files::containing CT[0-9,_,a-z]*.dcm | |
| RT_MRI_path | [Description] | SPARK/Westmead/Patient Pre RT from TROG/WM {patient_trial_id}/(?:review|diagnostic)/trial/15.01/{patient_trial_id}/files::containing MR[0-9,_,a-z]*.dcm;SPARK/Westmead/Patient Pre RT from TROG/WM {patient_trial_id}/(?:review|diagnostic)/trial/15.01/{patient_trial_id}/files/(?:CT|MRI)(%20)?[0-9](?:data)?::containing MR[0-9,_,a-z]*.dcm | |
| RT_dose_path | [Description] | SPARK/Westmead/Dose Reconstruction/Dose/PAT{centre_patient_no:02d}/Original Plan/RD[.,0-9,_,a-z,A-Z]*.dcm | |
| RT_DVH_original_path | [Description] | SPARK/Westmead/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/[A-Z,a-z,0-9,_]*Original[A-Z,a-z,_]*.txt | |
| RT_DVH_summed_no_track_path | [Description] | SPARK/Westmead/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/(?:PAT|Pat){centre_patient_no:02d}_PlanSum_?No(?:Track|Gate).txt | |
| RT_DVH_summed_track_path | [Description] | SPARK/Westmead/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/(?:PAT|Pat){centre_patient_no:02d}_PlanSum_?(?:Track|Gate).txt | |
| centroid_path | [Description] | SPARK/Westmead/Patient Files/PAT{centre_patient_no:02d}/WM{centre_patient_no:02d}_Centroid.txt | |

## Fraction Specific Data

Depending upon the number of fractions of treatment for every patient (usually 5), the following data is contained in seperate fraction level folders.

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| trajectory_logs | [Description] | SPARK/Westmead/Trajectory Logs/Pat{centre_patient_no:02d}(?: complete)?/{fraction_name};SPARK/Westmead/Trajectory Logs/Pat{centre_patient_no:02d}(?: complete)?/Fx{fraction_number} | |
| kim_logs | [Description] | SPARK/Westmead/Dose Reconstruction/Motion Trajectories/PAT{centre_patient_no:02d}/Fx{fraction_number:02d} | |
| DVH_track_path | [Description] | SPARK/Westmead/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/PAT{centre_patient_no:02d}_?Fx{fraction_number:02d}_?wKIM.txt | |
| DVH_no_track_path | [Description] | SPARK/Westmead/Dose Reconstruction/DVH/PAT{centre_patient_no:02d}/PAT{centre_patient_no:02d}_?Fx{fraction_number:02d}_(?:NoGate|nogate|woKIM).txt | |
| DICOM_no_track_plan_path | [Description] | SPARK/Westmead/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/Fx0{fraction_number}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]no[a-z,_]*.dcm;SPARK/Westmead/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]no[_,a-z]*.dcm;SPARK/Westmead/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]woKIM.dcm | |
| DICOM_track_plan_path | [Description] | SPARK/Westmead/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/Fx0{fraction_number}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]track[a-z,_]*.dcm;SPARK/Westmead/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]track[a-z]*.dcm;SPARK/Westmead/Dose Reconstruction/DICOM/PAT{centre_patient_no:02d}/[a-z,_]*P{centre_patient_no:02d}[_]*F[x,0]*{fraction_number}[_]wKIM.dcm | |
| KV_images | [Description] | SPARK/Westmead/Patient Images/PAT{centre_patient_no}[ ,-]*(?:{patient_trial_id})?/{fraction_name}/(?:KIM-)?KV | |
| MV_images | [Description] | SPARK/Westmead/Patient Images/PAT{centre_patient_no}[ ,-]*(?:{patient_trial_id})?/{fraction_name}/(?:KIM-)?MV[a-z, ]* | |
| metrics | [Description] | SPARK/Westmead/Triangulation/PAT{centre_patient_no}/{fraction_name}/'Metrics.xls | |
| triangulated_pos | [Description] | SPARK/Westmead/Triangulation/PAT{centre_patient_no}/{fraction_name}/'TriangulatedPositions.xls | |
