using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FurnitureItem
{
    public GameObject obj;
    public Vector3 position;
    public Vector3 rotation;
}

public class RoomController : MonoBehaviour
{
    GameObject furniture_root = null;

    public FurnitureItem[] room_set;
    
    // Start is called before the first frame update
    void Start()
    {
        furniture_root = this.gameObject.transform.Find("Furniture").gameObject;

        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Clear the room.
    public void Clear()
    {
        foreach (Transform child in furniture_root.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Popuate room with furniture.
    public void Populate()
    {
        for (var i = 0; i < room_set.Length; ++i)
        {
            FurnitureItem item = room_set[i];
            
            Quaternion rot = Quaternion.Euler(item.rotation);
            GameObject new_item = Object.Instantiate(item.obj, item.position, rot, furniture_root.transform);
        }
    }
}
