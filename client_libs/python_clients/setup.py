from setuptools import setup

setup(name='ImagingDBClient',
      version='0.2.1',
      description='The python client for the Realtime Imaging DB service',
      url='https://github.sydney.edu.au/Image-X/imaging_db_clients/tree/master/client_libs/python_clients',
      author='Indrajit Ghosh',
      author_email='indrajit.ghosh@sydney.edu.au',
      # license='Proprietary',
      packages=['ImagingDBClient'],
      install_requires=['requests', 'cryptography'],
      zip_safe=False)