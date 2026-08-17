using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] GameObject psPrefab;
    [SerializeField] GameObject dbPrefab;
    [SerializeField] GameObject suPrefab;

    int iItemRandom;
    GameObject spawnedObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

  public void ItemRandomizer(Transform spawnPosition)
    {
        iItemRandom = Random.Range(1, 4);

        switch (iItemRandom)
        {
            case 1:
                //psPrefab;
                 spawnedObj = Instantiate(psPrefab, spawnPosition.position, Quaternion.identity);

                break;
               
            case 2:
                //speedprefab;
               spawnedObj = Instantiate(suPrefab, spawnPosition.position, Quaternion.identity);
                break;

            case 3:
                //3. item
                spawnedObj = Instantiate(dbPrefab, spawnPosition.position, Quaternion.identity);
                break;

        }
    }

}
