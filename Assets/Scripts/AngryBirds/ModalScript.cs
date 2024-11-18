using UnityEngine;
using UnityEngine.SceneManagement;

public class ModalScript : MonoBehaviour
{
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private TMPro.TextMeshProUGUI titleTMP;
    [SerializeField]
    private TMPro.TextMeshProUGUI messageTMP;

    private static ModalScript instance;

    private string titleDefault;
    private string messageDefault;
    private bool isGameOverModal = false;

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

    public void OnResumeButtonClick()
{
    if (isGameOverModal)
    {
        Time.timeScale = 1.0f;
        isGameOverModal = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    else
    {
        content.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

    public void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void _Show(string title = null, string message = null, bool isGameOver = false)
    {
        isGameOverModal = isGameOver;
        Time.timeScale = 0.0f;
        content.SetActive(true);

        titleTMP.text = title ?? titleDefault;
        messageTMP.text = message ?? messageDefault;
    }

    public static void ShowModal(string title = null, string message = null, bool isGameOver = false)
    {
        instance._Show(title, message, isGameOver);
    }
}
