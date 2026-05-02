using UnityEngine;
using UnityEngine.UI;

public class BloodDrip : MonoBehaviour
{
    public Canvas canvas;
    public Sprite bloodSprite;
    public int numberOfDrips = 10;

    void Start()
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        float canvasWidth = canvasRect.rect.width;
        float spacing = canvasWidth / numberOfDrips;

        for (int i = 0; i < numberOfDrips; i++)
        {
            GameObject drip = new GameObject("Drip");
            drip.transform.SetParent(canvas.transform, false);

            Image img = drip.AddComponent<Image>();
            img.sprite = bloodSprite;
            img.color = new Color(0.9f, 0f, 0f, 1f);
            img.preserveAspect = true;

            RectTransform rect = drip.GetComponent<RectTransform>();
            float width = Random.Range(250f, 350f);
            float height = width * 4f;
            rect.sizeDelta = new Vector2(width, height);

            rect.anchorMin = new Vector2(0f, 1f);
            rect.anchorMax = new Vector2(0f, 1f);
            rect.pivot = new Vector2(0.5f, 1f);

            float xPos = spacing * i + Random.Range(-10f, 10f);
            rect.anchoredPosition = new Vector2(xPos, 0f);
        }
    }
}