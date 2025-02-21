using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Button newPatientButton;
    public Button continueButton;
    public Button submitMedicineButton;
    public Image PillPapaLogo;
    public Image InfoButton;
    [SerializeField] TextMeshProUGUI patientsLeft;
    [SerializeField] SelectObjectScript selectObjScript;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        InfoButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        submitMedicineButton.gameObject.SetActive(true);
        patientsLeft.gameObject.SetActive(false);
        PillPapaLogo.gameObject.SetActive(false);
        newPatientButton.gameObject.SetActive(false);
    }
}
