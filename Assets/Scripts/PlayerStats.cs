using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int HP;
    private int MaxHP = 100;

    private void Awake()
    {
        HP = MaxHP;
        PubSub.RegisterListener<SpikeCollEvent>(TakeDamage);
        PubSub.RegisterListener<GetHPEvent>(GetHP);

    }

    private void Start()
    {
        PubSub.Publish(new ChangeHPEvent { NewHP = HP });
    }

    public void TakeDamage(object publishedEvent)
    {
        SpikeCollEvent e = publishedEvent as SpikeCollEvent;
        HP -= e.Damage;
        PubSub.Publish(new ChangeHPEvent {  NewHP = HP });
        Debug.Log(HP);
    }
    public void GetHP(object publishedEvent)
    {
        GetHPEvent e = publishedEvent as GetHPEvent;
        HP += e.NewHP;
        PubSub.Publish(new ChangeHPEvent { NewHP = HP });
        Debug.Log(HP);
    }
}
