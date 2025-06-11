using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 20;
    public float ySpacing = 2f;

    void Start()
    {
        float chance = 0.0f;

        for (int i = 0; i < platformCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-2f, 2f), i * ySpacing, 0f);
            GameObject p = Instantiate(platformPrefab, pos, Quaternion.identity);

            Plattform platformScript = p.GetComponent<Plattform>();
            platformScript.breakChance = chance;

            chance += 0.05f; // wird immer schwerer
        }
    }
}