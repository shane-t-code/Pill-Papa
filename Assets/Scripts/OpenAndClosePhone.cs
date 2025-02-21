using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenAndClosePhone : MonoBehaviour
{
    public Animator phoneAnimator;
    public TextMeshProUGUI buttonText;

    public bool isPhoneOpen;

    // Start is called before the first frame update
    void Start()
    {
        phoneAnimator.SetBool("IsPhoneOpen", true);
        isPhoneOpen = true;
    }
    private void Update()
    {

    }

    public void TaskOnClick()
    {
        buttonText.text = "";
        if(isPhoneOpen == true)
        {
            ClosePhone();
        }
        else if (isPhoneOpen == false)
        {
            OpenPhone();
        }
    }



    public void OpenPhone()
    {
        phoneAnimator.SetBool("IsPhoneOpen", true);
        isPhoneOpen = true;
    }

    public void ClosePhone()
    {
        phoneAnimator.SetBool("IsPhoneOpen", false);
        isPhoneOpen = false;
    }
}
