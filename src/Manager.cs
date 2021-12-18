using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DictKey {
    public string key;
    public GameObject item;
}

public class Manager : MonoBehaviour
{

    public static Manager singleton;

    public DictKey[] keys;
    private Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();

    void Awake()
    {
        if (Manager.singleton == null) {
            Manager.singleton = this;
        }
    }

    void Start()
    {
        foreach (var obj in keys)
        {
            obj.item.SetActive(false);
            dict.Add(obj.key, obj.item);
        }
    }

    public void ActivateItem(string key)
    {
        GameObject obj;
        if (dict.TryGetValue(key, out obj)) {
            obj.SetActive(true);

        }
    }

    public void DisableItem(string key) 
    {
        GameObject obj;
        if (dict.TryGetValue(key, out obj)) {
            obj.SetActive(false);
        }
    }
}
