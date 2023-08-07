using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkillSycthe : MonoBehaviour
{
    private Collider2D boxCollider;
    private SkillSycthe skillSycthe;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<PolygonCollider2D>();
        skillSycthe = GetComponent<SkillSycthe>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.enabled && !skillSycthe.enabled)
        {
            skillSycthe.enabled = true;
        }
        else if (!boxCollider.enabled && skillSycthe.enabled)
        {
            skillSycthe.enabled = false;
        }
    }
}
