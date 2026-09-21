using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Керування з клавіатури (WASD або стрілочки)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Переміщення об'єкта
        transform.Translate(new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime);
    }

    // Виявлення фізичних зіткнень (OnCollisionEnter)
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Врізались у перешкоду: " + collision.gameObject.name);
    }

    // Робота з зонами-тригерами (OnTriggerEnter)
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Увійшли в зону-тригер: " + other.gameObject.name);
    }
}