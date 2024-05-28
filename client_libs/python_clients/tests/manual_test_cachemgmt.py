import sys
from ImagingDBClient.cachemgmt import FilesCacheManager


def create_cachemgr_instance() -> FilesCacheManager:
    # if encrypted cache is not required then initialise cache without any key
    # cacheMgr = FilesCacheManager()  

    # once cache is initialised, use the same key always!
    cacheMgr = FilesCacheManager(key="secret")   

    if not cacheMgr.cacheIndex:
        print("Cache initialisation probably failed", file=sys.stderr)
    return cacheMgr


def cache_some_content(cacheMgr:FilesCacheManager, url):
    testContent = b'{"patients": [{"num_markers": 3,"patient_no": 1,' \
        b'"patient_trial_id": "1000001","test_centre": "test"}]}"'
    if not cacheMgr.cache(url, content=testContent, 
                            fileType="application/json"):
        print("Caching failed", file=sys.stderr)
    else:
        print("Caching successful")


def lookup_cached_content(cacheMgr:FilesCacheManager, url):
    if not cacheMgr.lookup(url):
        print("Lookup failed", file=sys.stderr)
    else:
        print("Lookup successful")


def retrive_cached_content(cacheMgr:FilesCacheManager, url):
    content = cacheMgr.getFileContent(url)
    if not content:
        print("Getting cached content failed", file=sys.stderr)
    else:
        print("Got content:", content)


def main():
    cacheMgr = create_cachemgr_instance()
    testURL = "http://127.0.0.1:8090/patients?patient=1"
    cache_some_content(cacheMgr, testURL)
    lookup_cached_content(cacheMgr, testURL)
    retrive_cached_content(cacheMgr, testURL)


if __name__ == "__main__":
    main()
