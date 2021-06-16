using System;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    [SerializeField] private InteractableItems _items;

    [SerializeField] private Destinations _destinations;

    public InteractableItems InteractableItems => _items;

    public Destinations Destinations => _destinations;
}


// [SerializeField] private List<InteractableItem> _items;

// [SerializeField] private List<Transform> _destinations;

// public List<InteractableItem> Items => _items;

// public List<Transform> Destinations => _destinations;

// public InteractableItem GetItemByNameLinq(string name) =>
//     _items.Find(x => x.name == name);

// public Transform GetDestinationByNameLinq(string name) =>
//     _destinations.Find(x => x.name == name);
