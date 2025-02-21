using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PharmacyDatabaseScript
{
    public static Dictionary<string, string> SymptomMedicineMap = new Dictionary<string, string>
    {
        { "barking cough", "Delsyum" }, {"drowsiness", "Benadryl"}, {"nauseous", "Peptic Bismol"}, {"out of breath", "Nasal Spray"}, {"painfull swallowing", "Chloraseptic"}, {"burning sensation", "Pepcid"}, {"difficulty breathing", "Eucalyptus Mint"}
    };

    public static List<string> PatientNames = new List<string>
    {
        "Shane", "Aadi", "Kishan", "Harsha", "Lionel Messi", "Cristiano Ronaldo", "Elon Musk", "Tom Brady", "Joe Biden", "Dwayne Johnson", "Drake", "Tom Hanks", "Beyonce", "George Washington", "Donald Trump"
    };

    public static List<List<string>> Symptoms = new List<List<string>>
    {
        new List<string>{"I have a pretty bad barking cough"}, 
        new List<string>{"I have been feeling a lot of drowsiness lately"}, 
        new List<string>{ "I've felt very nauseous recently"}, 
        new List<string>{ "I've felt out of breath after running this past week"}, 
        new List<string>{"I don't know why, but I've had painfull swallowing for the past few days"}, 
        new List<string>{ "I've felt very nauseous recently"}, 
        new List<string>{ "I've had difficulty breathing after playing sports this week"}, 
        new List<string>{ "I have felt out of breath recently", "And I have also felt a lot of drowsiness recently"},
        new List<string>{ "For some reason I have felt a burning sensation in my body recently", "And I also have been experiencing a lot of drowsiness the past few days"},
        new List<string>{ "I've experienced some painfull swallowing the past 24 hours", "And I have also been feeling very nauseous"},
        new List<string>{ "I have been feeling very nauseous after eating my meals the past few days", "And I have also been experiencing a bad barking cough"}
    };
}
