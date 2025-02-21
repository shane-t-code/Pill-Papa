using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] OpenAndClosePhone phoneScript;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public float typeSentenceTime;
    //public Button continueButton;

    public Animator animator;

    private Queue<string> sentences;
    public List<string> medicines = new List<string>();

    public PharmacyDatabaseScript script;
    bool medicineFound = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue (Dialogue dialogue)
    {
        var rand = new System.Random();

        animator.SetBool("IsOpen", true);

        nameText.text = PharmacyDatabaseScript.PatientNames[rand.Next(0, PharmacyDatabaseScript.PatientNames.Count)];

        sentences.Clear();
        var randomSymptom = rand.Next(0, PharmacyDatabaseScript.Symptoms.Count);

        foreach (var symptom in PharmacyDatabaseScript.Symptoms[randomSymptom])
        {         
            sentences.Enqueue(symptom);
        }

        DisplayNextSentence();
        medicines = new MedicationFinder().FindMedicine(PharmacyDatabaseScript.Symptoms[randomSymptom]);
    }

    public void DisplayNextSentence()
    {
        //continueButton.gameObject.SetActive(true);
        if (medicineFound)
        {
            phoneScript.ClosePhone();
            EndDialogue();
            return;
        }

        if (sentences.Count == 0)
        {
            dialogueText.text = "This Patient Needs: " + string.Join(", ", medicines);
            medicineFound = true;
            return;
        }
        dialogueText.text = "";
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSentenceTime);
        }
        //continueButton.gameObject.SetActive(true);
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
