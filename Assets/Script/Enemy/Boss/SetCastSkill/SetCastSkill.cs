using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCastSkill : MonoBehaviour
{
    [SerializeField] private GameObject objectSetDirect;
    private SetObjectDirect setDirect;
    // Start is called before the first frame update

    void Start()
    {
        setDirect = objectSetDirect.GetComponent<SetObjectDirect>();
    }

    public void SetTrueCastSkill()
    {
        setDirect.SetCastSkill(true);
        PlayerPrefs.SetInt("castSkill", 1);
        PlayerPrefs.Save();
    }

    public void SetFalseCastSkill()
    {
        setDirect.SetCastSkill(false);
        PlayerPrefs.SetInt("castSkill", 0);
        PlayerPrefs.Save();
    }
}
