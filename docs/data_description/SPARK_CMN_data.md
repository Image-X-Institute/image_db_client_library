# Data Organisation Structure in CMN for SPARK Trial

This document provides an overall structure of the files located on the clinical trials data shared drive relevant to SPARK Trial conducted in CMN centre. The following lists the overall procedure level as well individual fraction level details. However, for all the path options, please refer to the site descriptor JSON file.

## Patient Procedure Level Data

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| centroid_path | Files containing the centroid locations of the markers | SPARK/CMN/Patient Files | This path contains one folder per patient, which contains a text filecontaining the centroid locations |
| RT_structure_path | The DICOM RT structure object | SPARK/CMN/Dose Reconstruction/Dose/_Patient_/Original Plan | The file name typically starts with the letters RS | 
| RT_plan_path | The DICOM object plan for radiation exposure marking the CTV, GTV etc. | SPARK/CMN/Dose Reconstruction/Dose/_Patient_/Original Plan |  |
| RT_CT_path | The DICOM CT series acquired before the procedure for creating the treatment plan | SPARK/CMN/Patient Plans/_Patient specific folder_/ | |
| RT_MRI_path | The DICOM MR series (optional) acquired  before the procedure | SPARK/CMN/Patient Plans/_Patient specific folder_/ | |
| RT_dose_path | DICOM Dose RT Object | SPARK/CMN/Dose Reconstruction/Dose/_Patient_/Original Plan | |
| RT_DVH_original_path | cumulative DVH file path  | SPARK/CMN/Dose Reconstruction/DVH/_Patient specific folder_/ | |
| RT_DVH_summed_no_track_path | Cumulative DVH path for no track | SPARK/CMN/Dose Reconstruction/DVH/_Patient specific folder_/ | |
| RT_DVH_summed_track_path | Cumulative DVH path with track | SPARK/CMN/Dose Reconstruction/DVH/_Patient specific folder_/ | |

## Fraction Specific Data

Depending upon the number of fractions of treatment for every patient (usually 5), the following data is contained in seperate fraction level folders.

| Field Name | Description | Path | Remarks |
| --- | --- | --- | --- |
| KV_images | The Kilovoltage images acquired during a fraction | SPARK/CMN/Patient Images/_patient Specific folder_/_Fraction Specific Folder_/KIM-KV | The path is a folder containing a number of KV images (usually in tiff format) |
| MV_images | The MV images acquired during a fraction | SPARK/CMN/Patient Images/_patient Specific folder_/_Fraction Specific Folder_/KIM-MV | |
| trajectory_logs | The trajectory logs | SPARK/CMN/Trajectory Logs/_Patient Specific Folder_/_Fraction Folder_/ | The path contains multiple files under each fraction folder |
| kim_logs | The KIM log files containing the reference to the acquired KV images | SPARK/CMN/Patient Measured Motion/_Patient Specific Folder_/_Fraction Folder_/ | |
| DVH_track_path | The DVH track files specific for each fraction | SPARK/CMN/Dose Reconstruction/DVH/_Patient Specific Folder_/ | The patient specific folder contains all the fraction level DVH files named according to the fraction number |
| DVH_no_track_path | The DVH no track files specific for each fraction | SPARK/CMN/Dose Reconstruction/DVH/_Patient Specific Folder_/ | The patient specific folder contains all the fraction level DVH files named according to the fractio number |
| DICOM_no_track_plan_path | The DICOM object containing the no track plan path | SPARK/CMN/Dose Reconstruction/DICOM/_Patient Specific Folder_/_Fraction Specific folder_/ | |
| DICOM_track_plan_path | The DICOM object containing the track plan path | SPARK/CMN/Dose Reconstruction/DICOM/_Patient Specific Folder_/_Fraction Specific folder_/ | |
| metrics | The marker positions spreadhseet | SPARK/CMN/Triangulation/_Patient Specific folder_/_Fraction Specific Folder_/'Metrics.xls | |
| triangulated_pos | The triangulated position file containing the marker positions | SPARK/CMN/Triangulation/_Patient Specific folder_/_Fraction Specific Folder_/'TriangulatedPositions.xls | These are CSV files |