using Assets.Scripts.BestScore;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DeathSequence : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private Player playerSO;
    [SerializeField]
    private GameObject deathScript;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private GameObject returnButton;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject staminaBar;
    [SerializeField]
    private GameObject shurikenCounter;
    [SerializeField]
    private GameObject pointsCounter;
    [SerializeField]
    private GameObject inputName;
    [SerializeField]
    private GameObject saveButton;
    [SerializeField]
    private Text inputValueText;
    [SerializeField]
    private GameObject errorMessage;
    [SerializeField]
    private GameObject passMessage;

    private string inputValue;

    public void Awake()
    {
        gameManager = GameManager.instance;
        deathScript.SetActive(false);
        restartButton.SetActive(false);
        returnButton.SetActive(false);
        inputName.SetActive(false);
        saveButton.SetActive(false);
        errorMessage.SetActive(false);
        passMessage.SetActive(false);
    }

    public void Update()
    {
        if (playerSO.isDead)
        {
            StartCoroutine(Launcher());
        }
    }

    public IEnumerator Launcher()
    {
        yield return new WaitForSeconds(2);
        Death();
    }

    public void Death()
    {
        Time.timeScale = 0;
        healthBar.SetActive(false);
        staminaBar.SetActive(false);
        shurikenCounter.SetActive(false);
        pointsCounter.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        deathScript.SetActive(true);
        restartButton.SetActive(true);
        returnButton.SetActive(true);
        inputName.SetActive(true);
        saveButton.SetActive(true);
    }

    public void RestartGame()
    {
        gameManager.ReloadGame();
    }

    [System.Obsolete]
    public void SaveGame()
    {
        var obj = new ScoreData
        {
            name = inputValueText.text,
            points = (int)PointsUI.points
        };
        string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        StartCoroutine(PostRequest(json));
    }

    [System.Obsolete]
    public IEnumerator PostRequest(string data)
    {
        Debug.Log(data);
        string uri = "https://skullsbackend.herokuapp.com/api/score";
        var uwr = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(data);
        uwr.uploadHandler = new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.downloadHandler.text.Contains("<!"))
        {
            errorMessage.SetActive(true);
        }
        else
        {
            errorMessage.SetActive(false);
            passMessage.SetActive(true);
            saveButton.SetActive(false);
        }
    }
}
