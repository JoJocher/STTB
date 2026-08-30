using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] GameObject m_goPaddleSizePrefab;
    [SerializeField] GameObject m_goDoubleBallPrefab;
    [SerializeField] GameObject m_goSpeedUpPrefab;

    public void SpawnRandomItem(Transform _spawnPosition)
    {
        // 50% Chance of an item to spawn.
        if (Random.Range(1, 3) == 1)
            return;

        int iItemRandom = Random.Range(1, 4);

        switch (iItemRandom)
        {
            case 1:
                Instantiate(m_goPaddleSizePrefab, _spawnPosition.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(m_goSpeedUpPrefab, _spawnPosition.position, Quaternion.identity);
                break;

            case 3:
                Instantiate(m_goDoubleBallPrefab, _spawnPosition.position, Quaternion.identity);
                break;
        }
    }
}
