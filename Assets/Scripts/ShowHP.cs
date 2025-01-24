using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ShowHP : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        PubSub.RegisterListener<ChangeHPEvent>(UIHPChange);
    }
    private void UIHPChange(object publishedEvent)
    {
        ChangeHPEvent e = publishedEvent as ChangeHPEvent;
        textMeshPro.text = "HP: " + e.NewHP.ToString();
    }
}
