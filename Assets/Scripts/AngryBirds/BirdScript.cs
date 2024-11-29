using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private float shotTimeout;
    [SerializeField]
    private int triesCount;
    [SerializeField]
    private Transform arrow;
    private ForceScript forceScript;
    private Rigidbody2D rb2d;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private float shotTime;
    private bool isShot;
    void Start()
    {
        GameState.triesCount = triesCount;
        shotTime = 0.0f;
        isShot = false;
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject.Find("ForceCanvasIndicator").GetComponent<ForceScript>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            float forceFactor = 2000.0f;
            if(forceScript != null)
            {
                forceFactor *= Time.timeScale * (forceScript.forceFactor + 0.5f);
            }
            else
            {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);
            isShot = true;
            shotTime = shotTimeout;
        }
        if (isShot)
        {
            shotTime-=Time.deltaTime;
            if (shotTime <= 0.0f)
            {
                GameState.triesCount -= 1;
                if (GameState.triesCount <= 0)
                {

                    GameState.triesCount = 0;
                    GameState.isLevelFailed = true;
                    ModalScript.ShowModal("Програш","Вичерпано кількість спроб");
                }
                isShot = false;

                this.transform.position = startPosition;
                this.transform.rotation = startRotation;

                rb2d.linearVelocity=Vector2.zero;
                rb2d.angularVelocity = 0.0f;
            }
        }
    }
}
