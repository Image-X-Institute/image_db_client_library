import unittest
import os
from tempfile import mkstemp, NamedTemporaryFile
from ImagingDBClient.cachemgmt import FilesCacheManager


class TestFileCaching(unittest.TestCase):
    def setUp(self) -> None:
        self.chacheMgr = FilesCacheManager(key="secret")
        self.testContent = b"This a test file content"

    def tearDown(self) -> None:
        ...

    def test_cache_creation(self) -> None:
        self.assertIsNotNone(self.chacheMgr)
        self.assertTrue(os.path.isdir(self.chacheMgr.cachePath), 
                        "Cache folder not created")
        self.assertIsInstance(self.chacheMgr.cacheIndex, dict, 
                        "cache index is not initialised")

    def test_new_file_caching(self) -> None:
        
        testUrl = "test_new_file_caching"
        self.chacheMgr.cache(testUrl, self.testContent)
        self.assertTrue(testUrl in self.chacheMgr.cacheIndex["index"], 
                        "caching index not updted with new URL")

    def test_cache_lookup(self) -> None:
        testUrl = "test_cache_lookup"
        self.chacheMgr.cache(testUrl, self.testContent)
        self.assertTrue(self.chacheMgr.lookup(testUrl), 
                        "cache lookup failed for newly cached item")

    def test_cache_miss(self) -> None:
        testUrl = "do_not_use_this_url_to_cache"
        self.assertFalse(self.chacheMgr.lookup(testUrl), 
                        "cache lookup incorrectly reported a cache miss")

    def test_cache_retrival(self) -> None:
        testUrl = "test_cache_retrival"
        self.chacheMgr.cache(testUrl, self.testContent)
        self.assertEqual(self.chacheMgr.getFileContent(testUrl), 
                        self.testContent,
                        "The cached content did not match the original")

    def test_cache_file_update(self) -> None:
        testUrl = "test_cache_file_update"
        self.chacheMgr.cache(testUrl, self.testContent)
        differentContent = b'This is a different file content'
        self.chacheMgr.cache(testUrl, differentContent)
        self.assertEqual(self.chacheMgr.getFileContent(testUrl), 
                        differentContent,
                        "The cached content did not match the original")


if __name__ == "__main__":
    unittest.main()
