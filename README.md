# Magic Leap Rest Client

A variety of examples showing you how to use my RestClient for Magic Leap projects.

Note: Be sure to enable "Internet" as a privilege in the Magic Leap settings.

```csharp
// send a get request
StartCoroutine(RestWebClient.Instance.HttpGet($"{baseUrl}api/values", (r) => OnRequestComplete(r)));

// setup the request header
RequestHeader header = new RequestHeader {
    Key = "Content-Type",
    Value = "application/json"
};

// send a post request
StartCoroutine(RestWebClient.Instance.HttpPost($"{baseUrl}api/values", 
JsonUtility.ToJson(new Player { FullName = "John Doe" }), 
    (r) => OnRequestComplete(r), new List<RequestHeader> { header } ));

```

Find latest versions of my RestClient source code at:
https://github.com/dilmerv/UnityRestClient