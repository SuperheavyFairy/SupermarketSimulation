using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemScript
{
    private string name;
    private int importPrice;
    private int sellingPrice;

    public string GetName{
        get {return this.name;}
    } 
    public int GetImportPrice {
        get {return this.importPrice;}
    }
    public void SetImportPrice(int price){
        this.importPrice = price;
    }
    public int GetSellingPrice {
        get {return this.sellingPrice;}
    }

    public void SetSellingPrice(int price){
        this.sellingPrice = price;
    }

}
