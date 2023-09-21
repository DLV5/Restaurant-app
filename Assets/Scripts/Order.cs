using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Order : MonoBehaviour
{
    public static Order Instance;

    [Serializable]
    private class OrderElement
    {
        public string name;
        public float price;
        public int count = 1;

        public OrderElement(string name, float price)
        {
            this.name = name;
            this.price = price;
        }

    }

    private bool _hasMatch = false;

    private List<OrderElement> order = new List<OrderElement>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddDishInOrder(string name, float price)
    {
        _hasMatch = false;

        foreach (var element in order)
        {
            if (element.name == name)
            {
                element.count++;
                _hasMatch = true;
                break;
            }
        }

        if(!_hasMatch)
        {
            order.Add(new OrderElement(name, price));
        }
    }

    public void RemoveDishfromOrder(string name, float price)
    {
        foreach (var element in order)
        {
            if (element.name == name)
            {        
                element.count--;
                _hasMatch = true;

                if (element.count < 1)
                {
                    order.Remove(element);
                }

                break;
            }
        }
    }

    public float GetTotalPrice()
    {
        float totalSum = 0;
        foreach (var element in order)
        {
            totalSum += element.price * element.count;
        }

        return totalSum;
    }

    public void SaveOrder()
    {
        StreamWriter writer = new StreamWriter("orderData.json");

        string json = JsonHelper.ToJson(order);

        writer.Write(json);

        writer.Close();

        Debug.Log("saved");
    }
}
