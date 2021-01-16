using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable
{
    public ulong age;
    public int growthStage;
    public int maxGrowth;
    public bool destroyOnHarvest;
    public float harvestAnimLength;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        age++;
    }

    public override void OnPlayerInteract()
    {
        base.OnPlayerInteract();
        if(growthStage == maxGrowth)
        {
            OnHarvest();
        }
    }

    public virtual void OnHarvest()
    {
        anim.SetBool("plantHarvest", true);
        if (destroyOnHarvest)
        {
            StartCoroutine(HarvestDestroyCoroutine());
        } else
        {
            StartCoroutine(HarvestCoroutine());
        }
    }

    public virtual void OnGrow()
    {
        if(growthStage != maxGrowth)
        {
            growthStage++;
        }
    }

    IEnumerator HarvestDestroyCoroutine()
    {
        yield return new WaitForSeconds(harvestAnimLength);
        anim.SetBool("plantHarvest", false);
        this.gameObject.SetActive(false);
    }

    IEnumerator HarvestCoroutine()
    {
        yield return new WaitForSeconds(harvestAnimLength);
        anim.SetBool("plantHarvest", false);
    }
}
