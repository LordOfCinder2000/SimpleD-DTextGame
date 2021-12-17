using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "NV")]
class NhanVat : ScriptableObject
{
    [SerializeField] Sprite Anh;
    [SerializeField] string Loai;
    [SerializeField]  int HP;
    [SerializeField]  int Damage;

    //public NhanVat(string Loai, int HP, int Damage)
    //{
    //    this.Loai = Loai;
    //    this.HP = HP;
    //    this.Damage = Damage;
    //}

    public string GetLoai()
    {
        return Loai;
    }
    public int GetHP()
    {
        return HP;
    }
    public int GetDamage()
    {
        return Damage;
    }

    public Sprite GetImage()
    {
        return Anh;
    }
}
