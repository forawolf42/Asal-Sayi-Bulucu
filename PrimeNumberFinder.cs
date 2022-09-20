using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PrimeNumberFinder : MonoBehaviour
{
    [SerializeField] private TMP_Text indexText;
    [SerializeField] private TMP_Text numberText;
    private UInt64 currentInt = 0;
    private UInt64 currentIndex = 0;

    private void Start()
    {
        try
        {
            currentInt = FurPrefs.GetData<UInt64>("int");
            currentIndex = FurPrefs.GetData<UInt64>("index");
        }
        catch (Exception e)
        {
        }
  
        StartCoroutine(NumberGenerator());

    }

    IEnumerator NumberGenerator()
    {
        UInt64 i = currentInt;
        while (true)
        {
            for (int z = 0; z < 25; z++)
            {
                bool asalsayi = true;
                for (UInt64 j = 0; j < i; j++)
                {
                    if (j != 0)
                    {
                        if (i % j == 0 && i / j != i && i / j != 1)
                        {
                            asalsayi = false;
                            break;
                        }
                    }
                }

                if (asalsayi)
                {
                    if (i != 1 && i != 0 && i!=currentInt)
                    {
                   
                        currentInt = i;
                        currentIndex++;
                        
                        if (currentIndex == 1000000)
                        {
                            FurPrefs.SaveData(currentInt,"birmilyoncu");
                        }
                        if (currentIndex == 300000)
                        {
                            FurPrefs.SaveData(currentInt,"yuzbininci");
                        }
                        FurPrefs.SaveData(i,"int");
                        FurPrefs.SaveData(currentIndex,"index");
                    }
             
                }

                i++;
                indexText.SetText(currentIndex.ToString());
                numberText.SetText(currentInt.ToString());
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}