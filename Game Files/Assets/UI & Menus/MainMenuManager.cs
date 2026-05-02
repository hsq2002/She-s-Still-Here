using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Scene Names")]
    public string gameSceneName = "GameScene";

    [Header("UI Buttons")]
    public Button continueButton;

    private const string SAVE_KEY = "HasSave";

    void Start()
    {
        if (continueButton != null)
        {
            bool hasSave = PlayerPrefs.GetInt(SAVE_KEY, 0) == 1;
            continueButton.interactable = hasSave;
        }
    }

    public void OnPlayButton()
    {
        Debug.Log("Play button clicked!");
        PlayerPrefs.SetInt(SAVE_KEY, 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnContinueButton()
    {
        if (PlayerPrefs.GetInt(SAVE_KEY, 0) == 1)
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }

    public void OnSettingsButton()
    {
        Debug.Log("Settings");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public static void RegisterSave()
    {
        PlayerPrefs.SetInt("HasSave", 1);
        PlayerPrefs.Save();
    }
}