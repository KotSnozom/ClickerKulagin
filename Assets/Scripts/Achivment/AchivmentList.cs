using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAchivmentList")]
public class AchivmentList :ScriptableObject
{
    [SerializeField] private List<Achivment> achivments;
    public IEnumerable<Achivment> Achivments => achivments;
}
