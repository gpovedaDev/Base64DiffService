# Base64DiffService
Diffs two base64 values

# The assignment
1. Provide 2 http endpoints that accepts JSON base64 encoded binary data on both endpoints
    - <host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right
2. The provided data needs to be diff-ed and the results shall be available on a third end point
    - <host>/v1/diff/<ID>
3. The results shall provide the following info in JSON format
    - If equal return that
    - If not of equal size just return that
    - If of same size provide insight in where the diffs are, actual diffs are not needed.
        - So mainly offsets + length in the data
4. Make assumptions in the implementation explicit, choices are good but need to be communicated

# Requirements
1. Microsoft WebApi
2. Owin SelfHost
3. Microsoft Unity
4. Visual Studio 2012
