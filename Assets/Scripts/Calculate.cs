using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    #region Fields
    private float result;

    public TextMeshProUGUI inputField;
    public TextMeshProUGUI seeInput;
    private string operation;
    float input;
    float inputTwo;
    string inputString;
    #endregion Fields



    #region Methods
    public void GetNum(int value)
    {
        if (input == 0)
        {
            inputString += value;
            input += value;
        }
        else
        {
            inputString += value;
            inputTwo += value;
        }
        inputField.text = inputString;
        seeInput.text = inputString;
    }
    public void GetOperator(string value)
    {
        operation = value;
        inputString += operation;
    }
    public void Decimal(string value)
    {
        seeInput.text = inputString + value.ToString();
        inputField.text += value;
    }
    public void ClearInput()
    {
        seeInput.text = "";
        inputField.text = "";
        inputString = "";

    }

    private void ResetInput()
    {
        input = 0;
        inputTwo = 0;
        seeInput.text = "";
        inputString = "";
    }

    public void ToggleNum()
    {
        input = -float.Parse(seeInput.text);
    }

    public void GetPercent()
    {
        input = float.Parse(seeInput.text) / 100.0f;
    }

    public void CalValue()
    {

        if (input != 0 && inputTwo != 0 && !string.IsNullOrEmpty(operation))
        {
            switch (operation)
            {
                case "+":
                    result = input + inputTwo;
                    print(result);
                    break;
                case "-":
                    result = input - inputTwo;
                    print(result);
                    break;
                case "*":
                    result = input * inputTwo;
                    print(result);
                    break;
                case "/":
                    result = input / inputTwo;
                    print(result);
                    break;
                case "%":
                    result = (input / inputTwo) * 100;
                    print(result);
                    break;
            }
            inputField.text = result.ToString();
            ResetInput();
        }
        else if (operation == "%")
        {
            result = input / 100;
        }

    }

    public void Quit()
    {
        Application.Quit();
        print("calculator has been closed");
    }
    #endregion Methods

}
