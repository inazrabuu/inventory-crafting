using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private TextMeshProUGUI _tooltipText;

    // Start is called before the first frame update
    void Start()
    {
        _tooltipText = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    public void GenerateTooltip(Item item)
    {
        string statText = "";
        foreach (var stat in item.stats)
        {
            statText += string.Format("{0}: {1}\n", stat.Key.ToString(), stat.Value.ToString());
        }

        string toolTipText = string.Format("<b>{0}</b>\n{1}\n\n{2}", item.title, item.description, statText);
        _tooltipText.text = toolTipText;
        gameObject.SetActive(true);
    }
}
