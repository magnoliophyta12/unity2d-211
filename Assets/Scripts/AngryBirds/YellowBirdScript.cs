using UnityEngine;

public class YellowBirdScript : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;
    private ForceScript forceScript;
    private Rigidbody2D rb2d;

    private bool hasDashed = false; 
    private float dashForceMultiplier = 3.0f; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        forceScript = GameObject.Find("ForceCanvasIndicator").GetComponent<ForceScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasDashed)
        {
            float forceFactor = 1000.0f;
            if (forceScript != null) 
            {
                forceFactor *= Time.timeScale * (forceScript.forceFactor + 0.5f);
            }
            else
            {
                Debug.LogError("forceScript NULL, used default");
            }
            rb2d.AddForce(forceFactor * arrow.right);
        }

        if (Input.GetKeyDown(KeyCode.F) && !hasDashed) 
        {
            Dash();
        }
    }

    private void Dash()
    {
        hasDashed = true; 
        float dashForce = 1000.0f * dashForceMultiplier;

        rb2d.linearVelocity = Vector2.zero; 
        rb2d.AddForce(dashForce * arrow.right, ForceMode2D.Impulse); 
    }
}