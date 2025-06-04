using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public static class ApiManager
{
    private const string AuthHeaderKey = "Authorization";

    /// <summary>
    /// Sends a GET request.
    /// </summary>
    public static IEnumerator Get(string url, Action<string> onSuccess, Action<string> onError, string authToken = null)
    {
        if (!IsValidUrl(url)) { onError?.Invoke("Invalid URL"); yield break; }

        UnityWebRequest request = UnityWebRequest.Get(url);
        AddAuthHeader(request, authToken);
        yield return SendRequest(request, onSuccess, onError);
    }

    /// <summary>
    /// Sends a POST request with JSON data.
    /// </summary>
    public static IEnumerator Post(string url, string jsonData, Action<string> onSuccess, Action<string> onError, string authToken = null)
    {
        if (!IsValidUrl(url)) { onError?.Invoke("Invalid URL"); yield break; }

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        AddAuthHeader(request, authToken);
        yield return SendRequest(request, onSuccess, onError);
    }

    /// <summary>
    /// Sends a PUT request with JSON data.
    /// </summary>
    public static IEnumerator Put(string url, string jsonData, Action<string> onSuccess, Action<string> onError, string authToken = null)
    {
        if (!IsValidUrl(url)) { onError?.Invoke("Invalid URL"); yield break; }

        UnityWebRequest request = UnityWebRequest.Put(url, jsonData);
        request.SetRequestHeader("Content-Type", "application/json");
        AddAuthHeader(request, authToken);
        yield return SendRequest(request, onSuccess, onError);
    }

    /// <summary>
    /// Sends a DELETE request.
    /// </summary>
    public static IEnumerator Delete(string url, Action<string> onSuccess, Action<string> onError, string authToken = null)
    {
        if (!IsValidUrl(url)) { onError?.Invoke("Invalid URL"); yield break; }

        UnityWebRequest request = UnityWebRequest.Delete(url);
        AddAuthHeader(request, authToken);
        yield return SendRequest(request, onSuccess, onError);
    }

    #region Helpers

    private static void AddAuthHeader(UnityWebRequest request, string authToken)
    {
        if (!string.IsNullOrEmpty(authToken))
            request.SetRequestHeader(AuthHeaderKey, $"Bearer {authToken}");
    }

    private static bool IsValidUrl(string url)
    {
        return Uri.IsWellFormedUriString(url, UriKind.Absolute);
    }

    private static IEnumerator SendRequest(UnityWebRequest request, Action<string> onSuccess, Action<string> onError)
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

    #endregion
}
