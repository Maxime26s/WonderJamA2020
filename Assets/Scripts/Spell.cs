using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type {Earth, Fire, Water, Air}

[CreateAssetMenu]
public class Spell : ScriptableObject
{
    public string name;
    public Type type;
    public Sprite sprite;
    public float damage;
    public List<BoutonManette> listeInputs = new List<BoutonManette>();
}
