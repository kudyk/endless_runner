using TMPro;
using UnityEngine;

public class UITextCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI uiTextCount = null;


    public void ShowCount(int count)
    {
        uiTextCount.SetText(count.ToString());
    }

    public void ShowCount(float count)
    {
        uiTextCount.SetText(Mathf.Floor(count).ToString());
    }
}