using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    public static APIManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    /// <summary>
    /// GET request.
    /// </summary>
    public void Get(string url, Action<string> onSuccess, Action<string> onError = null)
    {
        StartCoroutine(SendRequest(UnityWebRequest.Get(url), onSuccess, onError));
    }

    /// <summary>
    /// POST request with optional JSON body.
    /// </summary>
    public void Post(string url, string jsonBody, Action<string> onSuccess, Action<string> onError = null)
    {
        var request = new UnityWebRequest(url, "POST");
        UploadHandlerRaw uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonBody));
        request.uploadHandler = uploadHandler;
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        StartCoroutine(SendRequest(request, onSuccess, onError));
    }

    /// <summary>
    /// PUT request with optional JSON body.
    /// </summary>
    public void Put(string url, string jsonBody, Action<string> onSuccess, Action<string> onError = null)
    {
        var request = new UnityWebRequest(url, "PUT");
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonBody));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        StartCoroutine(SendRequest(request, onSuccess, onError));
    }

    /// <summary>
    /// DELETE request.
    /// </summary>
    public void Delete(string url, Action<string> onSuccess, Action<string> onError = null)
    {
        var request = UnityWebRequest.Delete(url);
        request.downloadHandler = new DownloadHandlerBuffer();

        StartCoroutine(SendRequest(request, onSuccess, onError));
    }

    /// <summary>
    /// Sends the request and invokes success or error callbacks.
    /// </summary>
    private IEnumerator SendRequest(UnityWebRequest request, Action<string> onSuccess, Action<string> onError)
    {
        yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
        if (request.result == UnityWebRequest.Result.Success)
#else
        if (!request.isNetworkError && !request.isHttpError)
#endif
        {
            onSuccess?.Invoke(request.downloadHandler.text);
        }
        else
        {
            onError?.Invoke(request.error);
        }
    }
}
