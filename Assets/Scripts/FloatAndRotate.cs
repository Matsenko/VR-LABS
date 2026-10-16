using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    [Header("Налаштування руху вгору-вниз")]
    public float floatSpeed = 1.5f;     // Швидкість коливання
    public float floatAmplitude = 0.05f; // Висота коливання (амплітуда)

    [Header("Налаштування обертання")]
    public bool rotateSmoothly = false;  // Чи крутити напис навколо осі?
    public float rotateSpeed = 30f;      // Швидкість обертання

    [Header("Постійний погляд на гравця (VR)")]
    public bool lookAtCamera = true;     // Чи завжди повертатися до очей гравця?
    private Transform mainCameraTransform;

    private Vector3 startPosition;

    void Start()
    {
        // Запам'ятовуємо початкову точку
        startPosition = transform.localPosition;

        // Знаходимо камеру гравця
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // 1. Плавне погойдування вгору-вниз за допомогою синусоїди
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.localPosition = new Vector3(startPosition.x, newY, startPosition.z);

        // 2. Плавне обертання (якщо увімкнено)
        if (rotateSmoothly)
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

        // 3. Поворот обличчям до камери (щоб текст завжди читався у VR)
        if (lookAtCamera && mainCameraTransform != null)
        {
            // Повертаємо об'єкт до камери, але ігноруємо нахили вгору/вниз (щоб текст не косило)
            Vector3 targetPostion = mainCameraTransform.position;
            targetPostion.y = transform.position.y;
            transform.LookAt(targetPostion);

            // Інвертуємо поворот на 180 градусів, якщо текст показується задом наперед
            transform.Rotate(0, 180, 0);
        }
    }
}