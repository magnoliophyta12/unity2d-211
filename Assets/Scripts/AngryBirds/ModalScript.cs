using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;
    [SerializeField]
    private Text resumeBtnText;

    private static ModalScript instance;

    private string titleDefault;
    private string messageDefault;

    void Start()
    {
        instance = this;
        titleDefault = titleTMP.text;
        messageDefault = messageTMP.text;

        if (content.activeInHierarchy)
        {
            Time.timeScale = 0.0f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (content.activeInHierarchy)
            {
                content.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                _Show();
            }
        }
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
        if (GameState.isLevelFailed)
        {
            SceneManager.LoadScene(GameState.sceneIndex);
        }
        else if (GameState.isLevelCompleted)
        {
            Time.timeScale = 1.0f;

            GameState.sceneIndex += 1;

            if (GameState.sceneIndex >= SceneManager.sceneCountInBuildSettings)
            {
                GameState.sceneIndex = 0; 
            }

            SceneManager.LoadScene(GameState.sceneIndex);
        }
        else
        {
            content.SetActive(false);
        }
    }

    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void _Show(string title = null, string message = null)
    {
        Time.timeScale = 0.0f;
        content.SetActive(true);

        titleTMP.text = title ?? titleDefault;
        messageTMP.text = message ?? messageDefault;
        if (GameState.isLevelFailed)
        {
            resumeBtnText.text = "онбрнпхрх";
        }
        if (GameState.isLevelCompleted)
        {
            resumeBtnText.text = GameState.sceneIndex == 0 ? "мюмнбн" : "опнднбфхрх";
        }
    }

    public static void ShowModal(string title = null, string message = null)
    {
        instance._Show(title, message);
    }
}
