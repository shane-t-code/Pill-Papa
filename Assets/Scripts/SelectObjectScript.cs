using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SelectObjectScript : MonoBehaviour
{
    [SerializeField] DialogueManager manager;
    [SerializeField] Button newPatientButton;
    [SerializeField] float distanceToHit;
    [SerializeField] TextMeshProUGUI patientsLeft;
    public List<string> medicineSelections = new List<string>();
    public bool completedPatient = false;
    public int numOfPatients = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, distanceToHit))
            {
                var ourObject = hit.collider.gameObject;
                if(ourObject.CompareTag("Medicine"))
                {
                    //if (manager.medicines.Contains(ourObject.name))
                    {
                        medicineSelections.Add(ourObject.name);
                    }
                    ourObject.SetActive(false);
                }
            }
        }
        int numOfPatientsLeft = 5 - numOfPatients;
        patientsLeft.text = "There are " + numOfPatientsLeft + " patients left!";
    }

    public void CompareMedicines()
    {
        if (medicineSelections.Intersect(manager.medicines).Count() == medicineSelections.Count)
        {
            completedPatient = true;
            numOfPatients += 1;
            newPatientButton.gameObject.SetActive(true);
            SceneManager.LoadScene("GameScreen");
            if (numOfPatients == 5)
            {
                SceneManager.LoadScene("WinScreen");
                PlayerPrefs.DeleteAll();
            }
        }
        else
        {
            SceneManager.LoadScene("LoseScreen");
            PlayerPrefs.DeleteAll();
            //Switch scene to game over screen
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("numPatients", numOfPatients);
    }

    private void OnEnable()
    {
        numOfPatients = PlayerPrefs.GetInt("numPatients");
    }
}
