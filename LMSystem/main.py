########################################################################################################################
#
# Daelon Von Davis
# CS361
# Microservice Project
#
# This microservice works by continually searching for a full length url written to "data_xfer.txt" on the machine
# that is running the program that requires the microservice. Once found, it calls the tinyurl API which converts and returns
# the shortened url, which is then written to "data_xfer.txt", overwriting the original contents. The shortened URL can then
# be used however is required by the program
#
########################################################################################################################

# Import for handling user supplied arguments
import sys
# import for URL shortener function
import contextlib
from urllib.parse import urlencode
from urllib.request import urlopen

def tinyURLshortener(url):
    # Append encoded url to tinyurl API url. Store
    api_url = ('http://tinyurl.com/api-create.php?' + urlencode({'url': url}))
    # the encoded url is opened -- calling the API. The contents of the resulting page is the tinyurl
    with contextlib.closing(urlopen(api_url)) as apiProduct:
        # page contents are returned from function, decoded
        return apiProduct.read().decode('utf-8 ')

def main():
    while True:
        # For arguments passed on terminal. Redundancy: program is not meant to interact with microservie this way
        # But I like redundancies, so
        if sys.argv[1:]:
            with open("data_xfer.txt", "r+") as f:
                for tinyurl in map(tinyURLshortener, sys.argv[1:]):
                    f.truncate(0)
                    f.seek(0)
                    f.write(tinyurl)
        # Intended function: argument is read from text file, processed and result is written to same file
        else:
            with open("data_xfer.txt", "r+") as f:
                foo = f.readline()
                url = [foo]
                # try/except is necessary because it's an infinite loop. It will keep searching and not throw an
                # error if there's nothing in the file, the file contents are a tinyurl and thus invalid argument for
                # tinyURLshortener and any other contingency
                try:
                    for tinyurl in map(tinyURLshortener, url):
                        f.truncate(0)
                        f.seek(0)
                        f.write(tinyurl)
                except:
                    pass


if __name__ == '__main__':
    main()