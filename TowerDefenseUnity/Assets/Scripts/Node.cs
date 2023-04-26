
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//build on nodes
public class Node : MonoBehaviour
{
    public Color hovercolor;
    public Vector3 positionOffset; //fix tower's position on node
  
    private Renderer rend;
    public int sellmoney=0;

    private Color startColor;
    BuildManager buildManager;
  
    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public Towers tower1; //curr tower
    [HideInInspector]
    public bool upgraded = false;
 

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance; //ref to build manager
    }
    private void OnMouseEnter()
    {

        if ((!buildManager.hasspace)) {  return; } //hovercolor only when u can build something
        rend.material.color = hovercolor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    public Vector3 GetBuildPos()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {

        

       
        //cant build, theres another turret there.Sell or upgrade
        if (tower != null) //we've built something
        {
           
           
            buildManager.SelectNode(this);
            return;
        }

        //check if can build
        if (!buildManager.hasspace) return;
        buildManager.Build(this);

        //Buid a turrent


    }
    public void UpgradeTower()
    {
        buildManager.Upgrade(this);
    }
    public void SellTower()
    {
        buildManager.Sell(this);
    }
}
