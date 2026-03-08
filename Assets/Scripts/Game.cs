using TMPro;
using UnityEngine;
using UnityEngine.UI;

// God class from hell.
// Static doer
public class Game : MonoBehaviour
{
    public static Game instance;

    [SerializeField]
    protected GameObject cardPrefab;

    public static CardInstance InstantiateCard(Transform parent)
    {
        GameObject newInstance = Instantiate(instance.cardPrefab);
        newInstance.transform.SetParent(parent);
        return newInstance.GetComponent<CardInstance>();
    }


    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
