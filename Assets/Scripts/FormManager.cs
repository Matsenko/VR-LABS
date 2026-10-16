using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FormManager : MonoBehaviour
{
    // Посилання на елементи інтерфейсу
    public Slider mySlider;
    public Toggle myToggle;
    public TMP_InputField myInputField;

    // Змінні для скидання до початкового стану
    private float defaultSlider = 0.5f;
    private bool defaultToggle = false;
    private string defaultInput = "";

    // Функція збереження (викликається кнопкою "Зберегти")
    public void SaveData()
    {
        Debug.Log("ДАНІ ЗБЕРЕЖЕНО! " +
                  "Повзунок: " + mySlider.value +
                  " | Чекбокс: " + myToggle.isOn +
                  " | Текст: " + myInputField.text);
    }

    // Функція скидання (викликається кнопкою "Скинути")
    public void ResetData()
    {
        mySlider.value = defaultSlider;
        myToggle.isOn = defaultToggle;
        myInputField.text = defaultInput;
    }
}