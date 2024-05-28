# Data Organisation Structure in Westmead for LARK Trial

This document provides an overall structure of the files located on the clinical trials data shared drive relevant to LARK Trial conducted in Westmead centre. The following lists the overall procedure level as well individual fraction level details. However, for all the path options, please refer to the site descriptor JSON file.

## Patient Procedure Level Data

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| RT_structure_path | The DICOM RT structure object | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/Dicom/Original/ | |
| RT_plan_path | The DICOM object plan for radiation exposure marking the CTV, GTV etc. | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/Dicom/Original/ | |
| RT_dose_path | DICOM Dose RT Object | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/Dicom/Original/ | |
| RT_DVH_original_path | cumulative DVH file path | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/DVH/PlannedDVH.txt | |
| RT_DVH_summed_no_track_path | Cumulative DVH path for no track | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/DVH/Sum tracking.txt | |
| RT_DVH_summed_track_path | Cumulative DVH path with track | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/DVH/Sum no tracking.txt | |
| centroid_path | Files containing the centroid locations of the markers | LARK/Westmead/Patient Files/_patient Specific folder_/ | |

## Fraction Specific Data

Depending upon the number of fractions of treatment for every patient (usually 5), the following data is contained in seperate fraction level folders.

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| trajectory_logs | The trajectory logs | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/Beam Tlogs/_Fraction specific folder_ | |
| kim_logs | The KIM log files containing the reference to the acquired KV images | LARK/Westmead/Patient Images/_patient Specific folder_/_fraction Specific folder_/KIM-KV | |
| DVH_track_path | The DVH track files specific for each fraction | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/DVH/ | |
| DVH_no_track_path | The DVH no track files specific for each fraction | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/DVH/ | |
| DICOM_no_track_plan_path | The DICOM object containing the no track plan path | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/Dicom/_fraction Specific folder_/ | |
| DICOM_track_plan_path | The DICOM object containing the track plan path | LARK/Westmead/Dose Reconstruction/_patient Specific folder_/Dicom/_fraction Specific folder_/ | |
| respiratory_files_path | files containing information regarding the respiratory movements | LARK/Westmead/RPM/_patient Specific folder_/_fraction Specific folder_/ | |
| KV_images | The Kilovoltage images acquired during a fraction | LARK/Westmead/Patient Images/_patient Specific folder_/_fraction Specific folder_/KIM-KV | |
| MV_images | The MV images acquired during a fraction | LARK/Westmead/Patient Images/_patient Specific folder_/_fraction Specific folder_/KIM-MV | |
| metrics | The marker positions spreadhseet | LARK/Westmead/Triangulations/_patient Specific folder_/_fraction Specific folder_/'Metrics.xls | |
| triangulated_pos | The triangulated position file containing the marker positions | LARK/Westmead/Triangulations/_patient Specific folder_/_fraction Specific folder_/'TriangulatedPositions.xls | |
