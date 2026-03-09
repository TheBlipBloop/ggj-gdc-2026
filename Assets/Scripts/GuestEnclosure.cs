using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class GuestEnclosure : MonoBehaviour
{
    [SerializeField]
    protected BoxCollider enclosureBoundsSource;

    [SerializeField]
    protected List<Guest> guests;

    [SerializeField]
    protected GameObject guestPrefab;

    // Door component?
    [SerializeField]
    protected Transform entrance;

    [SerializeField]
    protected float guestSpawnJitterY = 1f;

    private Bounds _enclosureBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enclosureBounds.size = enclosureBoundsSource.size;
        _enclosureBounds.center = enclosureBoundsSource.center;

        // Events.OnGuestsChanged.AddListener(OnGuestsChanged);
        Events.OnGuestsAdded.AddListener(OnGuestsAdded);
        Events.OnGuestKilled.AddListener(SacrificeGuests);
        Events.OnGuestLeaves.AddListener(OnGuestLeave);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < guests.Count; i++)
        {
            if (!guests[i].IsDoneResting())
            {
                continue;
            }

            guests[i].SetMoveTarget(GetValidGuestPosition());
        }
    }

    public Guest AddGuest()
    {
        GameObject newGuestObject = Instantiate(guestPrefab) as GameObject;
        Guest newGuest = newGuestObject.GetComponent<Guest>();

        guests.Add(newGuest);

        newGuest.transform.position = entrance.transform.position;
        newGuest.transform.position += Vector3.up * Random.Range(guestSpawnJitterY / -2f, guestSpawnJitterY / 2f);

        newGuest.SetMoveTarget(GetValidGuestPosition());

        return newGuest;
    }

    public void SacrificeGuests(int count)
    {
        for (int sacrificeIndex = 0; sacrificeIndex < count; sacrificeIndex++)
        {
            SacrificeGuest(FindRandomGuest());
        }
    }

    private Guest FindRandomGuest()
    {
        return guests[Random.Range(0, guests.Count)];
    }

    protected void SacrificeGuest(Guest target)
    {
        target.Sacrifice();
        guests.Remove(target);
    }

    protected void ExitGuest(Guest target)
    {
        target.SetMoveTarget(entrance.position);
        target.SetAsExiting();
        guests.Remove(target);
    }

    protected void OnGuestKilled(int delta)
    {
            SacrificeGuests(Mathf.Abs(delta));
    }

    protected void OnGuestLeave(int delta)
    {
        for (int i = 0; i < delta; i++)
        {
            ExitGuest(FindRandomGuest());
        }
    }

    protected void OnGuestsAdded(int newGuestCount)
    {
        for (int i = 0; i < newGuestCount; i++)
        {
            AddGuest();
        }
    }

    private Vector3 GetValidGuestPosition()
    {
        float x = Random.Range(_enclosureBounds.min.x, _enclosureBounds.max.x);
        float y = Random.Range(_enclosureBounds.min.y, _enclosureBounds.max.y);
        return new Vector3(x, y, 0);
    }
}
