using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItem : MonoBehaviour
{
   private TextMeshProUGUI itemText;
    int item;

    
  private void Awake()
    {
        itemText = gameObject.GetComponent<TextMeshProUGUI>();
        
    }
    private void Start()
    {
        RefreshUI();
    }
public void IncreaseItem(int scoreIncrement)
{
    item = item + scoreIncrement;
    RefreshUI();
}
private void RefreshUI()
{
    itemText.text = "KEY 6/ " + item;
}
}
