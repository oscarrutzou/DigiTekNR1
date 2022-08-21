using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int level = 1;
    [SerializeField] int experience = 0;

    [SerializeField] Menu menu; //Experience bar

    [SerializeField] int TO_LEVEL_UP
    {
        get { return level * 1000; } //Kunne lave if player er over lvl 20 så bliver det ganget med mere eller sådan noget.
    }

    private void Start()
    {
        menu.UpDateExperienceSlider(experience, TO_LEVEL_UP);
        menu.SetLevelText(level);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        menu.UpDateExperienceSlider(experience, TO_LEVEL_UP);
    }

    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            experience -= TO_LEVEL_UP;
            level += 1;
            menu.SetLevelText(level);
        }
    }
}
