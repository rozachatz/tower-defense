using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //reference, access the build manager from everywhere
    public AudioClip impact;
    AudioSource audioSource;
    public Text warning;
    public Text warning1;

    public UpgradSell_Script nodeui;
    public bool inbuild_method = false; float count = 0f;
    [HideInInspector]
    public Towers tower1; //curr turrent
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this; //every time we start the game, only one manager
    }
   

    public Towers tower_to_build;
    private Node selection;

    public void Select_tower_to_build(Towers t) //user selects tower
    {

        tower_to_build = t;
        Hidemenu();


    }

    public void Hidemenu()
    {
        selection = null;
        nodeui.hide(); //hide upgradesell ui when we want to build
    }

    public void SelectNode(Node node) //for node ui
    {
        if (node == selection)
        {
            //double click, hide. no upgrade or sell option enabled
            
            Hidemenu();return;
        }
        selection = node;
        tower_to_build = null;
        nodeui.SetTarget(node);//set to node pos, not inside of our node, upper (with offset)
    }
    public void Update()
    {
        if (inbuild_method && count >= 0)
        {
            count -= Time.deltaTime;
        }
        else
        {
            inbuild_method = false;
            warning.text = " ";
        }
    }
    public void Build(Node node)
    {
       
        if (Health.money < tower_to_build.price) {
                warning.text="Not enough money to build that!";
                count = 1f;
                inbuild_method = true;
                Debug.Log("Not enough money");
                return;
        }
        
        Health.money -= tower_to_build.price;
        GameObject my_tower =(GameObject)Instantiate(tower_to_build.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.tower1 = tower_to_build;
        node.tower = my_tower;
        node.sellmoney= node.tower1.price / 2;
        if (node.tower != null) audioSource.PlayOneShot(impact, 0.4F);
    }

    public bool hasspace { get { return tower_to_build != null; } } //no other tower
    public bool hasmoney { get { return tower_to_build.price <= Health.money; } } //enough money

    public void Upgrade(Node node)
    {
        if (node.upgraded)
        {
            warning.text = "Cant re-upgrade!"; //warn user
            count = 0.5f;
            inbuild_method = true;  Debug.Log("Cant re-upgrade"); return; }

        if (Health.money < node.tower1.upgraded_price)
        {
            warning.text = "Not enough money to upgrade that!"; //warn user
            count = 0.5f;
            inbuild_method = true; Debug.Log("Not enough money to upgrade that"); return;
        }

        Health.money -= node.tower1.upgraded_price;
        node.sellmoney = node.tower1.upgraded_price / 2;

        //destroy old tower
        Destroy(node.tower);

        //build new one
        GameObject turret = (GameObject)Instantiate(node.tower1.upgraded_prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.tower = turret;
        node.upgraded = true;

        if (node.tower != null) audioSource.PlayOneShot(impact, 0.4F);
    }

    public void Sell(Node node)
    {
        
        Health.money += node.sellmoney;
        Destroy(node.tower);
        node.tower1 = null;
        audioSource.PlayOneShot(impact, 0.4F);

    }
}
