using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathKeypadInput : MonoBehaviour
{
    private int userAnswer;

    public void setUserAnswer(int buttonInput) {
        userAnswer = buttonInput;
    }

    public int getUserAnswer() {
        return userAnswer;
    }
}
