using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokeTowerScript : MonoBehaviour
{
    private PokeType type;
    private int hp;
    Color32 damageColor;
    Color32 normalColor;

    // Use this for initialization
    void Start ()
    {
        damageColor = new Color32(255, 0, 0, 255);
        normalColor = new Color32(255, 255, 255, 255);
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        transform.GetComponentInParent<GameManagerScriptPT>().DealDamage(transform.gameObject, col.gameObject);
        Destroy(col.gameObject);
    }

    void OnMouseDown()
    {
        transform.GetComponentInParent<GameManagerScriptPT>().Execute(transform.gameObject);
    }

    public PokeType GetPokeType()
    {
        return type;
    }

    public int GetCurrentHp()
    {
        return hp;
    }

    public void ChangeType(PokeType newType, Sprite towerSprite)
    {
        this.type = newType;
        transform.GetComponent<SpriteRenderer>().sprite = towerSprite;
    }

    public void HealTower(int maxHp)
    {
        hp = maxHp;
        UpdateCanvas(hp);
    }

    public bool TakeDamage(int damage)
    {
        hp = Mathf.Max(0, (hp - damage));
        if (hp > 0)
        {
            StartCoroutine(DamageAnimation());
            UpdateCanvas(hp);
        }
        return (hp <= 0);
    }

    private IEnumerator DamageAnimation()
    {
        for (int i = 0; i < 5; i++)
        {
            transform.GetComponent<SpriteRenderer>().color = damageColor;
            yield return new WaitForSeconds(0.05f);
            transform.GetComponent<SpriteRenderer>().color = normalColor;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void Attack(Sprite attSprite, Vector3 position, Vector2 force)
    {
        //Instantiate attack ball
        GameObject attBall = new GameObject("AttackBall");

        //Set parent and position
        attBall.transform.parent = transform;
        attBall.transform.position = position;

        //Add comonents
        attBall.AddComponent<SpriteRenderer>();
        attBall.AddComponent<Rigidbody2D>();
        attBall.AddComponent<CircleCollider2D>();

        //Set components
        attBall.GetComponent<SpriteRenderer>().sprite = attSprite;
        attBall.GetComponent<CircleCollider2D>().radius = 0.45f;
        attBall.GetComponent<CircleCollider2D>().isTrigger = true;
        attBall.GetComponent<Rigidbody2D>().gravityScale = 0;
        attBall.GetComponent<Rigidbody2D>().AddForce(force);
    }

    private void UpdateCanvas(int hp)
    {
        Image img = transform.GetComponentInChildren<Image>();
        img.fillAmount = ((float)hp / (float)transform.GetComponentInParent<GameManagerScriptPT>().GetMaxHP());
    }
}
