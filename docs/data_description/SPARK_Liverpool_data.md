# Data Organisation Structure in Liverool for SPARK Trial

This document provides an overall structure of the files located on the clinical trials data shared drive relevant to SPARK Trial conducted in Liverpool centre. The following lists the overall procedure level as well individual fraction level details. However, for all the path options, please refer to the site descriptor JSON file.

## Patient Procedure Level Data

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| RT_structure_path | [Description] | SPARK/Liverpool/Dose Reconstructions/Dose/PAT{centre_patient_no:02d}/Original Plan/RS[.,0-9,_,a-z]*.dcm;SPARK/Liverpool/Patient Plans/{patient_trial_id}/{patient_trial_id}/RS[_,0-9]*{patient_trial_id}_DEIDENT_[0-9]*.dcm | |
| RT_plan_path | [Description] | SPARK/Liverpool/Dose Reconstructions/Dose/PAT{centre_patient_no:02d}/Original Plan/RP[.,0-9,_,a-z]*.dcm;SPARK/Liverpool/Patient Plans/{patient_trial_id}/{patient_trial_id}/RP[_,0-9]*{patient_trial_id}_DEIDENT_[0-9]*.dcm | |
| RT_CT_path | [Description] | SPARK/Liverpool/Image DICOM/zzSPARK_PAT{centre_patient_no:02d}::containing CT[0-9,_,a-z, ,.]*.dcm | |
| RT_MRI_path | [Description] | SPARK/Liverpool/Image DICOM/zzSPARK_PAT{centre_patient_no:02d}::containing MR[0-9,_,a-z, ,.]*.dcm | |
| RT_dose_path | [Description] | SPARK/Liverpool/Dose Reconstructions/Dose/PAT{centre_patient_no:02d}/Original Plan/RD[.,0-9,_,a-z,A-Z]*.dcm | |
| RT_DVH_original_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DVH/PAT{centre_patient_no:02d}/[A-Z,a-z,0-9,_]*Original[A-Z,a-z,_]*.txt | |
| RT_DVH_summed_no_track_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DVH/PAT{centre_patient_no:02d}/[a-z,A-Z,_,0-9]*PlanSum_?(?:No|wo)Track(?:ed|ing)?(_F2_5)?.txt | |
| RT_DVH_summed_track_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DVH/PAT{centre_patient_no:02d}/[a-z,A-Z,_,0-9]*PlanSum_?w?Track(?:ed|ing)?(_F2_5)?.txt | |
| centroid_path | [Description] | SPARK/Liverpool/Patient files/PAT{centre_patient_no:02d}.txt | |

## Fraction Specific Data
Depending upon the number of fractions of treatment for every patient (usually 5), the following data is contained in seperate fraction level folders.

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| trajectory_logs | [Description] | SPARK/Liverpool/Trajectory Logs/Pat{centre_patient_no:02d} ?- ?{patient_trial_id}/{fraction_name} | |
| kim_logs | [Description] | SPARK/Liverpool/{patient_trial_id}/{patient_trial_id}/Kim Logs/{fraction_name}|SPARK/Liverpool/Patient Motion Trajectories/Liverpool_PAT{centre_patient_no:02d}/{fraction_name} | |
| DVH_track_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DVH/PAT{centre_patient_no:02d}/[0-9,a-z,_]*Fx0{fraction_number}_?w?Track(?:ing)?.txt | |
| DVH_no_track_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DVH/PAT{centre_patient_no:02d}/[0-9,a-z,_]*Fx0?{fraction_number}_?(?:No|wo)(T|t)rack(?:ing)?.txt | |
| DICOM_no_track_plan_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DICOM/PAT{centre_patient_no:02d}/(RP.)?[0-9,A-Z,a-z,_]*Fx?_?0?{fraction_number}(?:PROST(_| )SPARK)?_(?:No|wo)_?((T|t)rack(?:ing)?|KIM).dcm | |
| DICOM_track_plan_path | [Description] | SPARK/Liverpool/Dose Reconstructions/DICOM/PAT{centre_patient_no:02d}/(RP.)?[0-9,A-Z,a-z,_]*Fx?_?0?{fraction_number}(?:PROST(_| )SPARK)?_w?((T|t)rack(?:ing)?|KIM).dcm | |
| KV_images | [Description] | SPARK/Liverpool/Patient Images/PAT{centre_patient_no:02d}/{fraction_name}/KV;SPARK/Liverpool/Patient Images/PAT{centre_patient_no:02d} - {patient_trial_id}/{fraction_name}/[a-z,0-9,_]*/[a-z,0-9,_]*/KIM-KV | |
| MV_images | [Description] | SPARK/Liverpool/Patient Images/PAT{centre_patient_no:02d}/{fraction_name}/MV;SPARK/Liverpool/Patient Images/PAT{centre_patient_no:02d} - {patient_trial_id}/{fraction_name}/[a-z,0-9,_]*/[a-z,0-9,_]*/KIM-MV | |
| metrics | [Description] | SPARK/Liverpool/Triangulation/PAT{centre_patient_no}/{fraction_name}/'Metrics.xls | |
| triangulated_pos | [Description] | SPARK/Liverpool/Triangulation/PAT{centre_patient_no}/{fraction_name}/'TriangulatedPositions.xls | |
