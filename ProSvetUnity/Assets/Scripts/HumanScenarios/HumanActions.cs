using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanActions : MonoBehaviour
{
    [SerializeField] protected float actionTimer;

    public const float timeToAction = 30;

    protected InteractiveItems interactiveItems;

    public NightEventSystem nightEventSystem;
    
}
