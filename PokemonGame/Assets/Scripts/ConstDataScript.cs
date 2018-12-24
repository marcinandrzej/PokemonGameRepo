using UnityEngine;

public enum PokeType
{
    NORMAL = 0,
    FIGHTING = 1,
    FLYING = 2,
    POISON = 3,
    GROUND = 4,
    ROCK = 5,
    BUG = 6,
    GHOST = 7,
    STEEL = 8,
    FIRE = 9,
    WATER = 10,
    GRASS = 11,
    ELECTRIC = 12,
    PSYCHIC = 13,
    ICE = 14,
    DRAGON = 15,
    DARK = 16,
    FAIRY = 17
};

public class ConstDataScript : MonoBehaviour
{
    //Attack multiplier value based on type table
    private int[,] attackValue;
    //Basic attack value
    private int baseAttackValue;

    //Towers sprites table
    public Sprite[] towerSprites;
    //Attack sprites table
    public Sprite[] attackSprites;

    // Use this for initialization
    void Start ()
    {
        int arrayDimension = System.Enum.GetNames(typeof(PokeType)).Length;
        attackValue = new int[arrayDimension, arrayDimension];
        baseAttackValue = 1;
        //NORMAL vs rest
        attackValue[(int)PokeType.NORMAL, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.ROCK] = 1 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.GHOST] = 0 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.NORMAL, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //FIGHTING vs rest
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.NORMAL] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.FLYING] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.POISON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.ROCK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.BUG] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.GHOST] = 0 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.STEEL] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.PSYCHIC] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.ICE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.DARK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIGHTING, (int)PokeType.FAIRY] = 1 * baseAttackValue;

        //FLYING vs rest
        attackValue[(int)PokeType.FLYING, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.FIGHTING] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.ROCK] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.BUG] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.GRASS] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.ELECTRIC] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FLYING, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //POISON vs rest
        attackValue[(int)PokeType.POISON, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.POISON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.GROUND] = 1 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.ROCK] = 1 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.GHOST] = 1 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.STEEL] = 0 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.GRASS] = 4 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.POISON, (int)PokeType.FAIRY] = 4 * baseAttackValue;

        //GROUND vs rest
        attackValue[(int)PokeType.GROUND, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.FLYING] = 0 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.POISON] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.ROCK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.BUG] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.STEEL] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.FIRE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.GRASS] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.ELECTRIC] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GROUND, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //ROCK vs rest
        attackValue[(int)PokeType.ROCK, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.FIGHTING] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.FLYING] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.GROUND] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.BUG] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.FIRE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.ICE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ROCK, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //BUG vs rest
        attackValue[(int)PokeType.BUG, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.FIGHTING] = 1 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.FLYING] = 1 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.POISON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.GHOST] = 1 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.FIRE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.GRASS] = 4 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.PSYCHIC] = 4 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.DARK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.BUG, (int)PokeType.FAIRY] = 1 * baseAttackValue;

        //GHOST vs rest
        attackValue[(int)PokeType.GHOST, (int)PokeType.NORMAL] = 0 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.GHOST] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.STEEL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.PSYCHIC] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.DARK] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GHOST, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //STEEL vs rest
        attackValue[(int)PokeType.STEEL, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.ROCK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.FIRE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.WATER] = 1 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.ELECTRIC] = 1 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.ICE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.STEEL, (int)PokeType.FAIRY] = 4 * baseAttackValue;

        //FIRE vs rest
        attackValue[(int)PokeType.FIRE, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.GROUND] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.BUG] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.STEEL] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.FIRE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.WATER] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.GRASS] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.ICE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.DRAGON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FIRE, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //WATER vs rest
        attackValue[(int)PokeType.WATER, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.GROUND] = 4 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.ROCK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.STEEL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.FIRE] = 4 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.WATER] = 1 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.GRASS] = 1 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.DRAGON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.WATER, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //GRASS vs rest
        attackValue[(int)PokeType.GRASS, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.FLYING] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.POISON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.GROUND] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.ROCK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.BUG] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.FIRE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.WATER] = 4 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.GRASS] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.DRAGON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.GRASS, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //ELECTRIC vs rest
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.FLYING] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.GROUND] = 0 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.STEEL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.WATER] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.GRASS] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.ELECTRIC] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.DRAGON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ELECTRIC, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //PSYCHIC vs rest
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.FIGHTING] = 4 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.POISON] = 4 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.PSYCHIC] = 1 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.DARK] = 0 * baseAttackValue;
        attackValue[(int)PokeType.PSYCHIC, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //ICE vs rest
        attackValue[(int)PokeType.ICE, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.FLYING] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.GROUND] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.FIRE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.WATER] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.GRASS] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.ICE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.DRAGON] = 4 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.ICE, (int)PokeType.FAIRY] = 2 * baseAttackValue;

        //DRAGON vs rest
        attackValue[(int)PokeType.DRAGON, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.FIGHTING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.DRAGON] = 4 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.DARK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DRAGON, (int)PokeType.FAIRY] = 0 * baseAttackValue;

        //DARK vs rest
        attackValue[(int)PokeType.DARK, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.FIGHTING] = 1 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.POISON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.GHOST] = 4 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.STEEL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.FIRE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.PSYCHIC] = 4 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.DRAGON] = 2 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.DARK] = 1 * baseAttackValue;
        attackValue[(int)PokeType.DARK, (int)PokeType.FAIRY] = 1 * baseAttackValue;

        //FAIRY vs rest
        attackValue[(int)PokeType.FAIRY, (int)PokeType.NORMAL] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.FIGHTING] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.FLYING] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.POISON] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.GROUND] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.ROCK] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.BUG] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.GHOST] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.STEEL] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.FIRE] = 1 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.WATER] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.GRASS] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.ELECTRIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.PSYCHIC] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.ICE] = 2 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.DRAGON] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.DARK] = 4 * baseAttackValue;
        attackValue[(int)PokeType.FAIRY, (int)PokeType.FAIRY] = 2 * baseAttackValue;
    }

    public int CountDamage(PokeType attType, PokeType defType)
    {
        return attackValue[(int)attType, (int)defType];
    }

    public Sprite GetTowerSprite(PokeType type)
    {
        return towerSprites[(int)type];
    }

    public Sprite GetAttackSprite(PokeType type)
    {
        return attackSprites[(int)type];
    }

    public PokeType GetType(int typeIndex)
    {
        return (PokeType)typeIndex;
    }
    public int GetBaseDamage()
    {
        return baseAttackValue;
    }
}
