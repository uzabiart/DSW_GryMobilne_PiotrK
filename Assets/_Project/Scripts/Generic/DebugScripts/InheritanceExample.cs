using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceExample : MonoBehaviour
{
    public Animal lion;
    public Animal trex;

    private void Start()
    {
        lion = new Lion();

        Debug.Log(lion.animalName + "turn");
        ((Lion)lion).roar.Play();
        ((Lion)lion).roar.Intimidate();
        ((Lion)lion).scratching.Play();

        trex = new Trex();

        Debug.Log(trex.animalName + "turn");
        ((Trex)trex).roar.Play();
        ((Trex)trex).roar.Intimidate();
    }
}


public abstract class Implementation
{
    public abstract void Play();
}

public class Roar : Implementation
{
    public Roar(int intimidation)
    {
        this.intimidation = intimidation;
    }

    public int intimidation;

    public void Intimidate()
    {
        Debug.Log($"Intimidation level: {intimidation}");
    }

    public override void Play()
    {
        Debug.Log("Roar logic");
    }
}

public class Scratch : Implementation
{
    public int scratchDamage;

    public override void Play()
    {
        Debug.Log("Scratch logic");
    }
}

public class Animal
{
    public virtual string animalName { get; }
    public int age;
    public int weight;

    public void Eat()
    { }
}

public class Lion : Animal
{
    public override string animalName { get => "Lion"; }
    public Roar roar = new Roar(6);
    public Scratch scratching = new Scratch();
}

public class Trex : Animal
{
    public override string animalName { get => "Trex"; }
    public Roar roar = new Roar(10);
}