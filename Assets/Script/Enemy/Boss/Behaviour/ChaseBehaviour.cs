using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject detechMeleSkill;
    [SerializeField] private GameObject chaseSkill;
    [SerializeField] private GameObject[] chaseSkillChildrens;
    [SerializeField] private GameObject chaseChild;
    private DetectionCollider detectionColliderMeleSkill;
    private QueueBehavier queueBehavier;

    // Start is called before the first frame update
    void Start()
    {
        detectionColliderMeleSkill = detechMeleSkill.GetComponent<DetectionCollider>();
        queueBehavier = chaseSkill.GetComponent<QueueBehavier>();
    }

    private void OnEnable()
    {
        chaseChild.SetActive(true);
        chaseSkill.SetActive(true);
        foreach (GameObject obj in chaseSkillChildrens)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        chaseSkill.SetActive(true);
        queueBehavier.enabled = true;
        if (PlayerPrefs.GetInt("castSkill") <= 0)
        {
            if (detectionColliderMeleSkill.isTouch)
            {
                chaseSkill.SetActive(true);
                queueBehavier.enabled = true;
                chaseChild.SetActive(false);
            }else if (!detectionColliderMeleSkill.isTouch)
            {
                chaseChild.SetActive(true);
                chaseSkill.SetActive(false);
                queueBehavier.enabled = false;
                foreach (GameObject obj in chaseSkillChildrens)
                {
                    obj.SetActive(false);
                }
            }
        }
        else
        {
            chaseChild.SetActive(false);
            //queueBehavier.enabled = false;
            //foreach (GameObject obj in chaseSkillChildrens)
            //{
            //    obj.SetActive(false);
            //}
        }
    }
}
