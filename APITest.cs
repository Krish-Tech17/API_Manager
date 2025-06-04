using System;
using Newtonsoft.Json;
using UnityEngine;
/*
public class APITest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetAPI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetAPI()
    {
        // GET example
        APIManager.Instance.Get("https://jsonplaceholder.typicode.com/posts/1",
        onSuccess: (response) => Debug.Log("GET success: " + response),
        onError: (error) => Debug.LogError("GET error: " + error));
    }

    void PostAPI()
    {
        // POST example with JSON
        string postData = JsonUtility.ToJson(new { name = "John", age = 30 });
        APIManager.Instance.Post("https://yourapi.com/users", postData,
        onSuccess: (response) => Debug.Log("POST success: " + response),
        onError: (error) => Debug.LogError("POST error: " + error));
    }


}*/

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Root
{
    public int id { get; set; }
    public string userid { get; set; }
    public string password { get; set; }
    public DateTime joined_at { get; set; }
    public DateTime first_login_at { get; set; }
    public DateTime last_login_at { get; set; }
    public int logins { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public object sms_email { get; set; }
    public object phone { get; set; }
    public bool teacher { get; set; }
    public bool student { get; set; }
    public bool assistant { get; set; }
    public bool administrator { get; set; }
    public bool monitor { get; set; }
    public bool mentor { get; set; }
    public object student_id { get; set; }
    public object teacher_id { get; set; }
    public object birthdate { get; set; }
    public object nick_name { get; set; }
    public object skype { get; set; }
    public object street_1 { get; set; }
    public object street_2 { get; set; }
    public object city { get; set; }
    public object state { get; set; }
    public object country { get; set; }
    public object zip { get; set; }
    public bool archived { get; set; }
    public string picture { get; set; }
    public object gender { get; set; }
    public DateTime archived_at { get; set; }
    public bool manager { get; set; }
    public bool active_this_month { get; set; }
    public object year_of_graduation { get; set; }
    public int organization_id { get; set; }

    [JsonProperty("date first logged into absorb")]
    public object datefirstloggedintoabsorb { get; set; }
    public object status { get; set; }

    [JsonProperty("date last logged onto absorb")]
    public object datelastloggedontoabsorb { get; set; }

    [JsonProperty("absorb department")]
    public object absorbdepartment { get; set; }

    [JsonProperty("number of logins on absorb")]
    public object numberofloginsonabsorb { get; set; }

    [JsonProperty("sent cypher new account details")]
    public bool sentcyphernewaccountdetails { get; set; }
    public object supervisor { get; set; }

    [JsonProperty("account name")]
    public object accountname { get; set; }

    [JsonProperty("enrollment key used")]
    public object enrollmentkeyused { get; set; }

    [JsonProperty("date added to absorb")]
    public object dateaddedtoabsorb { get; set; }

    [JsonProperty("date last edited on absorb")]
    public object datelasteditedonabsorb { get; set; }

    [JsonProperty("date of expiry (user)")]
    public object dateofexpiryuser { get; set; }

    [JsonProperty("imported company name")]
    public object importedcompanyname { get; set; }
    public object region { get; set; }
}


[Serializable]
public class LoginRequest
{
    public string username;
    public string password;
}

[Serializable]
public class LoginResponse
{
    public string token;
    public string userId;
}

public class APITest : MonoBehaviour
{
    private void Start()
    {
        string getUrl = "https://infinera.matrixlms.eu/api/get_my_account?api_key=922021b1117d5dd875dd094412da0f37580730b3e84e0500da0f";
        StartCoroutine(ApiManager.Get(getUrl,
            onSuccess: (response) => Debug.Log("GET Success: " + response),
            onError: (error) => Debug.LogError("GET Error: " + error)));

        string postUrl = "https://ind01.safelinks.protection.outlook.com/?url=https%3A%2F%2Finfinera-vmrouter-942121300977.asia-south1.run.app%2F&data=05%7C02%7CKS00924217%40TechMahindra.com%7Cb4dc90699d104fa64c4008dd920eefbd%7Cedf442f5b9944c86a131b42b03a16c95%7C0%7C0%7C638827315045541287%7CUnknown%7CTWFpbGZsb3d8eyJFbXB0eU1hcGkiOnRydWUsIlYiOiIwLjAuMDAwMCIsIlAiOiJXaW4zMiIsIkFOIjoiTWFpbCIsIldUIjoyfQ%3D%3D%7C0%7C%7C%7C&sdata=u0jSPdt52dDLugrRM7B4pRR%2FQ6YLYqLyjuMcXfyKjpI%3D&reserved=0";
        string postData = "{\"id\": \"foo\", \"userid\": \"bar\", \"password\": 1}";
        StartCoroutine(ApiManager.Post(postUrl, postData,
            onSuccess: (response) => Debug.Log("POST Success: " + response),
            onError: (error) => Debug.LogError("POST Error: " + error)));
    }

}

