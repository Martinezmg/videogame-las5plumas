using UnityEngine;

public class ProgressBarUI : MonoBehaviour
{
    public ProgressAsset asset;

    public SpriteRenderer[] days;

    private Color visible = new Color(255,255,255,255);
    private Color noVisible = new Color(0, 0, 0, 0);

    private void Start()
    {
        days = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0, j = asset.DaysPassed; i < days.Length; i++, j--)
        {
            if (j > 0)
                days[i].color = visible;
            else
                days[i].color = noVisible;
        }

        asset.DayOver += UpdateProgress;
    }

    private void UpdateProgress()
    {
        for (int i = 0, j = asset.DaysPassed; i < days.Length; i++, j--)
        {
            if (j > 0)
                days[i].color = visible;
            else
                days[i].color = noVisible;
        }
    }


}
