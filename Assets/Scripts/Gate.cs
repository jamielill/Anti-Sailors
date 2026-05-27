using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gate : MonoBehaviour
{
    [SerializeField] private int piratesLeft = 10;
    [SerializeField] private TMP_Text piratesLeftText;
        
    void Start()
    {
        UpdateText();
    }

    public void RemovePirate()
    {
        piratesLeft--;
        if(piratesLeft <= 0)
        {
            Destroy(gameObject);
        }
        else 
		{
			UpdateText();
		}
    }

    private void UpdateText()
	{
		piratesLeftText.text = "pirates left " + (piratesLeft).ToString();
	}
    
}
