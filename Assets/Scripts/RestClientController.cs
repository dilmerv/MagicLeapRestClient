using System;
using RestClient.Core;
using RestClient.Core.Models;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

[RequireComponent(typeof(ControllerConnectionHandler))]
public class RestClientController : MonoBehaviour
{   
    private ControllerConnectionHandler _controllerConnectionHandler;

    [SerializeField]
    private string url = "";

    [SerializeField]
    private Text responseDataText;

    void Start()
    {
        _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();
        MLInput.OnControllerButtonDown += HandleButtonDown;
    }

#if UNITY_EDITOR
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Space))
        {
            MakeRestClientHTTPCall();
        }
    }
#endif

    private void MakeRestClientHTTPCall()
    {
        Debug.Log("Making HTTP Call");
        // send a get request
        StartCoroutine(RestWebClient.Instance.HttpGet(url, (r) => OnRequestComplete(r)));
    }
    
    private void OnRequestComplete(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
        responseDataText.text = $"{DateTime.Now.ToString()} Data: {response.Data}";
    }

    private void HandleButtonDown(byte controllerId, MLInputControllerButton button)
    {
        MLInputController controller = _controllerConnectionHandler.ConnectedController;
        if (controller != null && button == MLInputControllerButton.Bumper)
        {
            MakeRestClientHTTPCall();
        }
    }
}
