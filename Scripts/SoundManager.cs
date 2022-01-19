using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip AttackSound1, AttackSound2, AttackSound3, ArrowSound, AttackSoundCastle,ContinueSound,MeteorSound,BulletSound,ShipBreakSound;
    public static AudioClip DeathSound,WinSound,LoseSound,Diamond, UnlockSound,ButtonClick,MagicSpell,CriticalHit,Stun,SpeedSound,ShieldSound;
    public static AudioClip CoronaAttack, CoronaDie,BatDie,BatonSound,GolemAttackSound,GolemStunSound,DangerSound;
    static AudioSource audioSrc;
    void Start()
    {
        AttackSound1 = Resources.Load<AudioClip>("attack1");
        AttackSound2 = Resources.Load<AudioClip>("attack2");
        AttackSound3 = Resources.Load<AudioClip>("attack3");
        ArrowSound = Resources.Load<AudioClip>("arrowsound");
        AttackSoundCastle = Resources.Load<AudioClip>("attackCastle");
        DeathSound = Resources.Load<AudioClip>("death");
        WinSound = Resources.Load<AudioClip>("winsound");
        Diamond = Resources.Load<AudioClip>("diamond");
        UnlockSound = Resources.Load<AudioClip>("unlocksound");
        ButtonClick = Resources.Load<AudioClip>("buttonclick");
        MagicSpell = Resources.Load<AudioClip>("magicspell");
        CriticalHit = Resources.Load<AudioClip>("criticalhit");
        Stun = Resources.Load<AudioClip>("stun");
        ContinueSound = Resources.Load<AudioClip>("continuesound");
        SpeedSound = Resources.Load<AudioClip>("speedsound");
        ShieldSound = Resources.Load<AudioClip>("shieldsound");
        BulletSound = Resources.Load<AudioClip>("bullet");
        ShipBreakSound = Resources.Load<AudioClip>("shipbreak");
        CoronaAttack= Resources.Load<AudioClip>("coronaAttack");
        CoronaDie = Resources.Load<AudioClip>("coronaDie");
        BatDie= Resources.Load<AudioClip>("batdie");
        BatonSound= Resources.Load<AudioClip>("baton");
        GolemAttackSound= Resources.Load<AudioClip>("golemsound");
        GolemStunSound = Resources.Load<AudioClip>("golemStun");
        DangerSound= Resources.Load<AudioClip>("danger");
        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        if (clip == "attack1") audioSrc.PlayOneShot(AttackSound1);
        else if (clip == "attack2") audioSrc.PlayOneShot(AttackSound2);
        else if (clip == "attack3") audioSrc.PlayOneShot(AttackSound3);
        else if (clip == "death") audioSrc.PlayOneShot(DeathSound);
        else if (clip == "attackCastle") audioSrc.PlayOneShot(AttackSoundCastle);
        else if (clip == "arrowsound") audioSrc.PlayOneShot(ArrowSound);
        else if (clip == "winsound") audioSrc.PlayOneShot(WinSound);
        else if (clip == "diamond") audioSrc.PlayOneShot(Diamond);
        else if (clip == "unlocksound") audioSrc.PlayOneShot(UnlockSound);
        else if (clip == "buttonclick") audioSrc.PlayOneShot(ButtonClick);
        else if (clip == "magicspell") audioSrc.PlayOneShot(MagicSpell);
        else if (clip == "criticalhit") audioSrc.PlayOneShot(CriticalHit);
        else if (clip == "stun") audioSrc.PlayOneShot(Stun);
        else if (clip == "continuesound") audioSrc.PlayOneShot(ContinueSound);
        else if (clip == "shieldsound") audioSrc.PlayOneShot(ShieldSound);
        else if (clip == "speedsound") audioSrc.PlayOneShot(SpeedSound);
        else if (clip == "bullet") audioSrc.PlayOneShot(BulletSound);
        else if (clip == "shipbreak") audioSrc.PlayOneShot(ShipBreakSound);
        else if (clip == "coronaAttack") audioSrc.PlayOneShot(CoronaAttack);
        else if (clip == "coronaDie") audioSrc.PlayOneShot(CoronaDie);
        else if (clip == "batdie") audioSrc.PlayOneShot(BatDie);
        else if (clip == "baton") audioSrc.PlayOneShot(BatonSound);
        else if (clip == "golemsound") audioSrc.PlayOneShot(GolemAttackSound);
        else if (clip == "golemStun") audioSrc.PlayOneShot(GolemStunSound);
        else if (clip == "danger") audioSrc.PlayOneShot(DangerSound);
    }
}
