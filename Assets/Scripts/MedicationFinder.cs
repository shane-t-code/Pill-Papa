using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MedicationFinder
{
    string pattern = @"\b";
    public MedicationFinder()
    {
        foreach (var symptom in PharmacyDatabaseScript.SymptomMedicineMap.Keys)
        {
            pattern += symptom + @"\b" + "|" + @"\b";
        }
    }
    //string pattern = @"\b" + "fever" + @"\b" + "|" + @"\b" + "vomiting" + @"\b";

    public List<string> FindMedicine(List<string> Symptoms)
    {
        List<string> patientMedicine = new List<string>();
        //Parse the sentence for keywords
        Regex rgx = new Regex(pattern);
        foreach (var symptom in Symptoms)
        {
            MatchCollection matches = rgx.Matches(symptom);

            foreach (Match match in matches)
            {
                if (PharmacyDatabaseScript.SymptomMedicineMap.TryGetValue(match.Value, out var medicine))
                {
                    patientMedicine.Add(medicine);
                }


            }
        }



        //Use map to find the medicine that matches keyword
        return patientMedicine;
    }
}
