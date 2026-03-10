using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour
{
    [SerializeField]
    protected GameObject gravePrefab;

    private List<GameObject> _graves = new List<GameObject>();


    [SerializeField]
    protected int graveRows = 5;

    [SerializeField]
    protected int graveColumns = 3;

    [SerializeField]
    protected Transform graveOrigin;

    [SerializeField]
    protected Vector2 graveSpacing = new Vector2(0.25f, 0.5f);

    /*
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Events.OnSacrificesChanged.AddListener(UpdateGraveCount);
        }

        // Update is called once per frame
        void Update()
        {

        }

        protected void UpdateGraveCount(int delta)
        {
            Debug.Assert(delta != 0);

            bool add = delta > 0;
            if (add)
            {
                for (int i = 0; i < delta; i++)
                {
                    AddGrave();
                }
            }
            else
            {
                for (int i = 0; i < -delta; i++)
                {
                    RemoveGrave();
                }
            }
        }

        protected void AddGrave()
        {
            GameObject newGrave = Instantiate(gravePrefab);
            _graves.Add(newGrave);

            newGrave.transform.position = GetGravePosition(_graves.Count);

            print("adding grave");
        }

        protected void RemoveGrave()
        {
            _graves.RemoveAt(_graves.Count - 1);
            Destroy(_graves[_graves.Count - 1]);

            print("remove grave");
        }

        protected Vector3 GetGravePosition(int graveIndex)
        {
            // TODO : Fix this when the mind may math.
            // its wrong.
            int row = graveIndex / graveColumns;
            int col = graveIndex % graveColumns;

            float x = row * graveSpacing.x;
            float y = col * graveSpacing.y;

            return new Vector3(x, y, 0) + graveOrigin.position;
        }
        */
}
