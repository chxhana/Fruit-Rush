using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathKeypadInput : MonoBehaviour
{
    private int userAnswer = -1;
    [SerializeField] private TextMeshProUGUI randomNumbersText;
    [SerializeField] private GameObject mathUI;
    [SerializeField] private Text collectablesText;
    private int collectables = 0;
    private static int randomX;
    private static int randomY;
    private static int correctAnswer;

    public void setUserAnswer(int buttonInput) {
        userAnswer = buttonInput;
    }

    public int getUserAnswer() {
        return userAnswer;
    }

    public static void setRandomNumbers() {
        do {
            randomX = Random.Range(1,9);
            randomY = Random.Range(1,10);
        } while (randomX + randomY > 9);
        correctAnswer = randomX + randomY;
        Debug.Log("Random numbers: " + randomX + " and " + randomY);
    }

    void Start() {
        Debug.Log("Starting math UI...");
        mathUI.SetActive(false);
    }

    void Update() {
        if (ItemCollector.getCollisionPresent()) {
            if (userAnswer <= -1) {
                mathUI.SetActive(true);
                Time.timeScale = 0f;
                randomNumbersText.text = randomX + " + " + randomY + " =";
            } else {
                Time.timeScale = 1f;
                if (userAnswer == correctAnswer) {
                    Debug.Log("Correct Answer!");
                    collectables++;
                    collectablesText.text = "Items: " + collectables;
                }
                else {
                    Debug.Log("Incorrect Answer.");
                }
                mathUI.SetActive(false);
                userAnswer = -1;
                ItemCollector.setCollisionPresent(false);
            }
        }
    }
}
