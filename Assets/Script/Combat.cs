using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{

    private GameObject typeSlot;
    private GameObject powerSlot;
    private GameObject elementSlot;

    private GameObject typeItem;
    private GameObject powerItem;
    private GameObject elementItem;

    private string type;
    private string power;
    private string element;

    public GameObject combatTextBox;
    private Text combatText;

    private int playerHealth;
    private int damage;
    private int heal;
    private int block;
    public Text playerHealthText;

    private int enemyHealth;
    private int enemyDamage;
    private int enemyDamageReduction;
    public Text enemyHealthText;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        playerHealthText.text = "Your Health: " + playerHealth.ToString();
        enemyHealth = 100;
        enemyHealthText.text = "Enemy Health: " + enemyHealth.ToString();
        typeSlot = GameObject.Find("TypeSlot");
        powerSlot = GameObject.Find("PowerSlot");
        elementSlot = GameObject.Find("ElementSlot");
        combatText = combatTextBox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "Your Health: " + playerHealth.ToString();
        enemyHealthText.text = "Enemy Health: " + enemyHealth.ToString();

        if (enemyHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void EndTurn()
    {
        if (typeSlot.transform.childCount > 0)
        {
            typeItem = typeSlot.transform.GetChild(0).gameObject;
        } else
        {
            typeItem = null;
        }
        if (powerSlot.transform.childCount > 0)
        {
            powerItem = powerSlot.transform.GetChild(0).gameObject;
        }
        else
        {
            powerItem = null;
        }
        if (elementSlot.transform.childCount > 0)
        {
            elementItem = elementSlot.transform.GetChild(0).gameObject;
        }
        else
        {
            elementItem = null;
        }

        if (typeItem)
        {
            type = typeItem.GetComponent<ItemProperties>().type;
        } else
        {
            type = null;
        }
        if (powerItem)
        {
            power = powerItem.GetComponent<ItemProperties>().power;
        } else
        {
            power = null;
        }
        if (elementItem)
        {
            element = elementItem.GetComponent<ItemProperties>().element;
        } else
        {
            element = null;
        }

        enemyDamage = 15;

        combatText.text = "";

        if (type!=null && power!=null)
        {
            if (type == "attack")
            {
                if (power == "weak")
                {
                    damage = 10;
                }
                else if (power == "medium")
                {
                    damage = 20;
                }
                else if (power == "strong")
                {
                    damage = 30;
                }
                if (element != null)
                {
                    if (element == "water" || element == "earth") //if attack element is strong against monster element
                    {
                        damage = damage * 2;
                    }
                    else if (element == "ice" || element == "plant") //if attack element is weak against monster element
                    {
                        damage = damage / 2;
                    }
                }
                combatText.text = combatText.text + "You hit the enemy for " + damage.ToString() + " damage.\n";
                enemyHealth -= damage;
            }
            else if (type == "heal")
            {
                if (power == "weak")
                {
                    heal = 10;
                }
                else if (power == "medium")
                {
                    heal = 20;
                }
                else if (power == "strong")
                {
                    heal = 30;
                }
                combatText.text = combatText.text + "You heal yourself for " + heal.ToString() + " health.\n";
                playerHealth += heal;
            }
            if (type == "block")
            {
                if (power == "weak")
                {
                    block = 4;
                }
                else if (power == "medium")
                {
                    block = 3;
                }
                else if (power == "strong")
                {
                    block = 2;
                }
                enemyDamageReduction = enemyDamage / block;
                if (element != null)
                {
                    if (element == "water" || element == "earth") //if block element is strong against enemy element
                    {
                        enemyDamageReduction *= 2;
                    }
                    else if (element == "ice" || element == "plant") //if block element is weak against enemy element
                    {
                        enemyDamageReduction /= 2;
                    }
                }
                combatText.text = combatText.text + "You block " + enemyDamageReduction.ToString() + " incoming damage.\n";
                enemyDamage -= enemyDamageReduction;
            }
            combatText.text = combatText.text + "Enemy strikes for 15 damage.\n";
            combatText.text = combatText.text + "You take " + enemyDamage.ToString() + " damage.\n";
            playerHealth -= enemyDamage;
        } else
        {
            combatText.text = "invalid";
        }

    }

}
