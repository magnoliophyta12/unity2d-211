using UnityEngine;

public class HexagonScript : MonoBehaviour
{


    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2d.AddForce(Vector2.up * 300);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(Vector2.right * 300);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb2d.AddForce(Vector2.left * 300);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2d.AddTorque(300);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb2d.angularVelocity = 0;
            rb2d.linearVelocity = Vector2.zero;
        }


        /* Д.З. Фізика. Основи
 * - створити межі по всіх сторонах поля зору камери (ліво, право, верх, низ)
 * - реалізувати фізичне управління об'єктом із задіянням 
 *     всіх напрямів прикладання сили (ліво, право, верх)
 * - при натисканні стрілки "вниз" додавати обертального моменту (Torque) тілу
 * - при натисканні (відпусканні) ESC прибирати дію всіх сил
 *    = присвоїти ноль для rb2d.angularVelocity
 *    = присвоїти ноль-вектор для rb2d.linearVelocity
 */
    }
}
