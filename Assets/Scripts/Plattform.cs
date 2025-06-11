using UnityEngine;

public class Plattform : MonoBehaviour
{
    public float breakChance = 0.1f; // 10 % Absturzchance

    private void Update()
    {
        if (WillBreak())
        {
            Destroy(gameObject);
        }
    }
    public bool WillBreak()
    {
        float r = Random.value; // 0.0 – 1.0
        return r < breakChance;
    }
}