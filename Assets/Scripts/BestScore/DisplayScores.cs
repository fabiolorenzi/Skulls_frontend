using Assets.Scripts.BestScore;
using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DisplayScores : MonoBehaviour
{
    [SerializeField]
    private Text[] lines;

    [System.Obsolete]
    public void Start()
    {
        GetData();
    }

    [System.Obsolete]
    public void GetData()
    {
        StartCoroutine(GetScore());
    }

    [System.Obsolete]
    public IEnumerator GetScore()
    {
        string uri = "https://skullsbackend.herokuapp.com/api/score";
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                lines[0].text = "No data available";
            }
            else
            {
                var preData = request.downloadHandler.text;
                ScoreData[] casualData = JsonConvert.DeserializeObject<ScoreData[]>(preData);
                ScoreData[] data = casualData.OrderByDescending(x => x.points).ToArray();
                for (int x = 0; x < lines.Length; x++)
                {
                    lines[x].text = (x + 1).ToString() + ". " + data[x].name + ": " + data[x].points;
                }
            }
        }
    }

    // https://www.youtube.com/watch?v=lnwOq0kW4ms
}
