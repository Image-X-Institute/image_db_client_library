

function details = RealtimeImageDB(endpoint, test_centre, patient_num)

%     base_url = 'http://localhost:8090';
    base_url = 'http://10.65.67.179:8090';
    query = ['?centre=' test_centre '&patient=' num2str(patient_num)];
    
    details = webread([base_url '/' endpoint query]);
    return
end
