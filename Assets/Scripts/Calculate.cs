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
    private AudioSource calcAudio;
    public AudioClip clickSound, operatorSound, clearSound, resetSound;
    private bool isPositive = false;
    #endregion Fields



    #region Methods

    private void Start()
    {
        calcAudio = GetComponent<AudioSource>();
    }
    public void GetNum(int value)
    {
        if (input == 0)
        {
            inputString += value;
            input += value;
            inputField.text = input.ToString();
        }
        else
        {
            inputString += value;
            inputTwo += value;
            inputField.text = inputTwo.ToString();
        }
        seeInput.text = inputString;

        calcAudio.PlayOneShot(clickSound, .6f);
    }
    public void GetOperator(string value)
    {
        operation = value;
        inputString += operation;
        calcAudio.PlayOneShot(operatorSound, .6f);
    }
    public void Decimal(string value)
    {
        seeInput.text = inputString + value.ToString();
        inputField.text += value;
        result = input + inputTwo;
    }
    public void ClearInput()
    {
        input = 0;
        inputTwo = 0;
        seeInput.text = "";
        inputField.text = "";
        inputString = "";
        calcAudio.PlayOneShot(clearSound, .6f);
    }

    private void ResetInput()
    {
        input = 0;
        inputTwo = 0;
        seeInput.text = "";
        inputString = "";
        calcAudio.PlayOneShot(resetSound, .6f);
    }

    public void ToggleNum()
    {
        //input = -float.Parse(seeInput.text);
        if (isPositive)
        {
            input = -float.Parse(inputString);
            isPositive = false;
        } else
        {
            input = float.Parse(inputString);
            isPositive=true;
        }
    }

    public void GetPercent()
    {
       // input = float.Parse(seeInput.text) / 100.0f;
        result = (input * 1) / 100;

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
            }
            inputField.text = result.ToString();
            ResetInput();
        }
        else if (input != 0 && inputTwo == 0 && !string.IsNullOrEmpty(operation))
        {
            switch (operation)
                {
                    case "%":
                        GetPercent();
                        break;
                }
        }
    }

    public void Quit()
    {
        Application.Quit();
        print("calculator has been closed");
    }
    #endregion Methods

}
