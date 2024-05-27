using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressLine = null;


    public void UpdateProgress(float fillAmount)
    {
        progressLine.fillAmount = fillAmount;
    }

    public void UpdateProgressClamped(float fillAmount)
    {
        UpdateProgress(Mathf.Clamp01(fillAmount));
    }

    public void ResetState(bool isFull)
    {
        UpdateProgress(isFull ? 1.0f : 0.0f);
    }
}