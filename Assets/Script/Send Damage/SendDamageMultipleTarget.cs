using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SendDamageMultipleTarget : MonoBehaviour
{
    [SerializeField] protected string tagTakeDamage;
    [SerializeField] protected float damage = 10f;
    protected Life life;
    protected LifeWithRevival lifeWithRevival;
    [SerializeField] protected bool isSent = false;
    protected List<int> ListIdSentDamage = new List<int>(); 
}