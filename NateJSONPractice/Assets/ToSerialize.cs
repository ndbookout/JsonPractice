using UnityEngine;
using UnityEngine.Experimental.Networking;
using System.Collections;
using JsonFx.Json;
using System.IO;
using System.Text;

public class ToSerialize : MonoBehaviour {

    public Dude randomDude = new Dude();
    public Account newAccount = new Account();

    public RootObject[] wahevers;

    public string fileName;
    private string path;

    private string wahever = @"[
  {
    ""active"": true,
    ""avatarId"": 24,
    ""description"": ""Person at a podium"",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Speaker Event"",
    ""prescribedActivityId"": 2,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 31,
    ""description"": ""Teacher in front of class"",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Education Event"",
    ""prescribedActivityId"": 3,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 32,
    ""description"": ""Icon of a calendar."",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""General Meeting"",
    ""prescribedActivityId"": 4,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 33,
    ""description"": ""Round table meeting"",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Implementation Meeting"",
    ""prescribedActivityId"": 5,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 12,
    ""description"": ""Shaking hands with an opinionated rock star."",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Introduce Customer to a KOL"",
    ""prescribedActivityId"": 6,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 15,
    ""description"": ""Meeting with a \""silenced alarm\"" prominently displayed."",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Meeting to discuss alarm audit"",
    ""prescribedActivityId"": 7,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 13,
    ""description"": ""Meeting about a \""line chart going up\"" to represent a gathering of people to discuss how to improve quality. QIP = quality improvement program. "",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Meeting to discuss QIP"",
    ""prescribedActivityId"": 8,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 18,
    ""description"": ""Meeting about a \""pledge\""; to represent taking a pledge to improve outcomes. "",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Meeting to discuss outcomes pledge"",
    ""prescribedActivityId"": 9,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 17,
    ""description"": ""Meeting with a rocket taking off; to represent a stakeholders meeting to discuss a successful launch of a new product."",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Meeting to discuss a product launch"",
    ""prescribedActivityId"": 10,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 16,
    ""description"": ""Jim's team will be meeting with lots of clinicians to discuss the possibility of them visiting a Premier Center of Excellence so that they can listed to KOL's and other key personnel at the CoE discuss best practices, processes, outcomes, etc."",
    ""metadata"": {
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Meeting to discuss hosting a Speaking Event"",
    ""prescribedActivityId"": 11,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 27,
    ""description"": ""Go live milestone"",
    ""metadata"": {
      ""createDate"": ""2016-04-11T22:04:00Z"",
      ""createUser"": 0,
      ""updateUser"": 0
    },
    ""name"": ""Go-Live"",
    ""prescribedActivityId"": 1,
    ""type"": ""962""
  },
  {
    ""active"": true,
    ""avatarId"": 0,
    ""description"": ""Delete me"",
    ""metadata"": {
      ""createDate"": ""2016-04-12T04:04:32.641Z"",
      ""createUser"": 16,
      ""current"": ""Y"",
      ""updateUser"": 0
    },
    ""name"": ""Test activity"",
    ""prescribedActivityId"": 12,
    ""type"": ""event""
  },
  {
    ""active"": true,
    ""avatarId"": 0,
    ""description"": ""Delete me"",
    ""metadata"": {
      ""createDate"": ""2016-04-12T04:05:30.63Z"",
      ""createUser"": 16,
      ""current"": ""Y"",
      ""updateUser"": 0
    },
    ""name"": ""Test activity"",
    ""prescribedActivityId"": 13,
    ""type"": ""event""
  },
  {
    ""active"": false,
    ""avatarId"": 0,
    ""description"": ""They really do have cookies."",
    ""metadata"": {
      ""createDate"": ""2016-04-12T04:06:37.49Z"",
      ""createUser"": 29,
      ""current"": ""Y"",
      ""updateDate"": ""2016-04-12T04:08:38.671Z"",
      ""updateUser"": 29
    },
    ""name"": ""The Dark Side"",
    ""prescribedActivityId"": 14,
    ""type"": ""event""
  }
]";


    public void Start()
    {
        randomDude.name = "Bobby";
        randomDude.age = 29;
        randomDude.height = 4.02f;
        randomDude.weight = 597.29f;

        path = Application.dataPath + "/../TestData/";

        newAccount.name = "Elrond";
        newAccount.position = new Position();
        newAccount.address = new Address();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("SAVE"))
        {
            SerializeAndSave();
        }
        if (GUILayout.Button("LOAD"))
        {
            LoadAndDeserialize();
        }
        if (GUILayout.Button("READJSON"))
        {
            IterateString();
        }
        if (GUILayout.Button("Request"))
        {
            StartCoroutine(MakeWebRequest());
        }
        if (GUILayout.Button("Upload"))
        {
            StartCoroutine(MakeUploadRequest());
        }
        if(GUILayout.Button("Delete"))
        {
            StartCoroutine(DeleteWebRequest());
        }
    }

    private IEnumerator MakeUploadRequest()
    {
        string uploadData = JsonWriter.Serialize(newAccount);
        UnityWebRequest newUploadRequest = UnityWebRequest.Post("https://dev.landscape-app.com/api/accounts/add", uploadData);

        Debug.Log(uploadData);

        newUploadRequest.SetRequestHeader("Content-Type", "application/json");
        newUploadRequest.SetRequestHeader("Accept", "application/json");
        newUploadRequest.SetRequestHeader("Authorization", "Bearer eyJraWQiOiIyVUY3VDhWMFZUVTI1UkY1VUMwWENETlJSIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiI2YlpMaGNPaE9VYlhhVWdJaEZZOG5kIiwiaWF0IjoxNDYxMDEyMDU1LCJpc3MiOiJodHRwczovL2FwcDQ0MjUyNDA5LmlkLnN0b3JtcGF0aC5pbyIsInN1YiI6Imh0dHBzOi8vYXBpLnN0b3JtcGF0aC5jb20vdjEvYWNjb3VudHMvNjVkamJVVmlWNURZazNVa3N2TkN2cSIsImV4cCI6MTQ2MTAxNTY1NSwicnRpIjoiWDVMTzJtYjNCVExuWGpuMExPaGNzIn0.SzrjjpabVbqNsDw1JDvgcf_8x-2-lswUduLAfM0XWH8");

        UploadHandlerRaw handler = new UploadHandlerRaw(Encoding.ASCII.GetBytes(uploadData));
        handler.contentType = "application/json";
        newUploadRequest.uploadHandler = handler;
        
        yield return newUploadRequest.Send();

        if (newUploadRequest.isError)
        {
            Debug.Log(newUploadRequest.error);
        }
        else
        {
            Debug.Log(newUploadRequest.downloadHandler.text);
        }
    }

    private IEnumerator DeleteWebRequest()
    {
        UnityWebRequest deleteWR = UnityWebRequest.Delete("https://dev.landscape-app.com/api/accounts/delete/3440");
        deleteWR.SetRequestHeader("Accept", "application/json");
        deleteWR.SetRequestHeader("Authorization", "Bearer eyJraWQiOiIyVUY3VDhWMFZUVTI1UkY1VUMwWENETlJSIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiI2YlpMaGNPaE9VYlhhVWdJaEZZOG5kIiwiaWF0IjoxNDYxMDEyMDU1LCJpc3MiOiJodHRwczovL2FwcDQ0MjUyNDA5LmlkLnN0b3JtcGF0aC5pbyIsInN1YiI6Imh0dHBzOi8vYXBpLnN0b3JtcGF0aC5jb20vdjEvYWNjb3VudHMvNjVkamJVVmlWNURZazNVa3N2TkN2cSIsImV4cCI6MTQ2MTAxNTY1NSwicnRpIjoiWDVMTzJtYjNCVExuWGpuMExPaGNzIn0.SzrjjpabVbqNsDw1JDvgcf_8x-2-lswUduLAfM0XWH8");
        yield return deleteWR.Send();

        if (deleteWR.isError)
        {
            Debug.Log(deleteWR.error);
        }
        else
        {
            Debug.Log("Success");
        }
    }

    private IEnumerator MakeWebRequest()
    {
        
        UnityWebRequest newWR = UnityWebRequest.Get("https://dev.landscape-app.com/api/prescribedActivities/getAll");
        newWR.SetRequestHeader("Accept", "application/json");
        newWR.SetRequestHeader("Authorization", "Bearer eyJraWQiOiIyVUY3VDhWMFZUVTI1UkY1VUMwWENETlJSIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiI2UFNNSFVZNjJCR2Iya29GV3dBeU9ZIiwiaWF0IjoxNDYwNTc0Mzg3LCJpc3MiOiJodHRwczovL2FwcDQ0MjUyNDA5LmlkLnN0b3JtcGF0aC5pbyIsInN1YiI6Imh0dHBzOi8vYXBpLnN0b3JtcGF0aC5jb20vdjEvYWNjb3VudHMvNjVkamJVVmlWNURZazNVa3N2TkN2cSIsImV4cCI6MTQ2MDU3Nzk4NywicnRpIjoiWDVMTzJtYjNCVExuWGpuMExPaGNzIn0._em9d6_f71CAPHgjfBJdou8RwyB70epSnSyszXhxJ68");
        yield return newWR.Send();

        if (newWR.isError)
        {
            Debug.Log(newWR.error);
        }
        else
        {
            RootObject[] activities = JsonReader.Deserialize<RootObject[]>(newWR.downloadHandler.text);

            for (int i = 0; i < activities.Length; i++)
                Debug.Log(activities[i].name);
        }
        
        
        //Add header called "Authorization" with value:
        //"Bearer eyJraWQiOiIyVUY3VDhWMFZUVTI1UkY1VUMwWENETlJSIiwiYWxnIjoiSFMyNTYifQ.eyJqdGkiOiI2UFNNSFVZNjJCR2Iya29GV3dBeU9ZIiwiaWF0IjoxNDYwNTc0Mzg3LCJpc3MiOiJodHRwczovL2FwcDQ0MjUyNDA5LmlkLnN0b3JtcGF0aC5pbyIsInN1YiI6Imh0dHBzOi8vYXBpLnN0b3JtcGF0aC5jb20vdjEvYWNjb3VudHMvNjVkamJVVmlWNURZazNVa3N2TkN2cSIsImV4cCI6MTQ2MDU3Nzk4NywicnRpIjoiWDVMTzJtYjNCVExuWGpuMExPaGNzIn0._em9d6_f71CAPHgjfBJdou8RwyB70epSnSyszXhxJ68"

    }

    private void SerializeAndSave()
    {
        string data = JsonWriter.Serialize(randomDude);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        var streamWriter = new StreamWriter(path + fileName + ".txt");
        streamWriter.Write(data);
        streamWriter.Close();
    }
    private void LoadAndDeserialize()
    {
        var streamReader = new StreamReader(path + fileName + ".txt");
        string data = streamReader.ReadToEnd();
        streamReader.Close();

        randomDude = JsonReader.Deserialize<Dude>(data);
    }

    private void IterateString()
    {
        wahevers = JsonReader.Deserialize<RootObject[]>(wahever);

        for (int i = 0; i < wahevers.Length; i++)
        {
            Debug.Log(wahevers[i].name);
        }
    }
}
