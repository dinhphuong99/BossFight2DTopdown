using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{
    [SerializeField] private AudioSource meleSkillSound;
    [SerializeField] private AudioSource runAwaySkillSound;
    [SerializeField] private GameObject meleSkill;
    [SerializeField] private GameObject runAwaySkill;
    // Biến cờ theo dõi trạng thái của object
    private bool meleSkillActiveLastFrame = false;
    private bool runAwaySkillActiveLastFrame = false;

    // Biến cờ để kiểm tra xem object đã được khai báo hay chưa
    private bool meleSkillDeclared = false;
    private bool runAwaySkillDeclared = false;

    // Kiểm tra trạng thái của object
    private bool isMeleSkillActive;
    private bool isRunAwaySkillActive;

    // Start is called before the first frame update
    void Start()
    {
        // Kiểm tra xem objectReset đã được khai báo hay chưa
        if (meleSkill != null)
        {
            meleSkillDeclared = true;
        }

        if (runAwaySkill != null)
        {
            runAwaySkillDeclared = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra trạng thái của meleSkill
        isMeleSkillActive = meleSkillDeclared && meleSkill != null && meleSkill.activeSelf;

        // Nếu meleSkill trở thành active từ trạng thái không active trong frame trước đó
        if (isMeleSkillActive && !meleSkillActiveLastFrame)
        {
            meleSkillSound.Play();
        }

        meleSkillActiveLastFrame = isMeleSkillActive;

        // Kiểm tra trạng thái của runAwaySkill
        isRunAwaySkillActive = runAwaySkillDeclared && runAwaySkill != null && runAwaySkill.activeSelf;

        // Nếu runAway trở thành active từ trạng thái không active trong frame trước đó
        if (isRunAwaySkillActive && !runAwaySkillActiveLastFrame)
        {
            runAwaySkillSound.Play();
        }

        runAwaySkillActiveLastFrame = isRunAwaySkillActive;
    }
}
