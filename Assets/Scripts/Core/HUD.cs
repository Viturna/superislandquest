using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
	[SerializeField] private GameObject deathText; //On insère l'objet texte qui affiche le nombre de morts
	[SerializeField] private GameObject levelText; //On insère l'objet texte qui affiche le numéro du niveau
	[SerializeField] private GameObject timerText; //On insère l'objet texte qui affiche le compteur de temps
    [SerializeField] private GameObject moneyText;

    public void updateDeathText(int nbDeath){
		deathText.GetComponent<TMP_Text>().text = " " + nbDeath;
	}
	
	public void updateLevelText(int numLevel){
		levelText.GetComponent<TMP_Text>().text = "Niveau " + numLevel;
	}
    public void updateMoneyText(int nbMoney)
    {
        moneyText.GetComponent<TMP_Text>().text = nbMoney + " pièce(s)";
    }

    public void updateTimer(float time){
		//Permet d'arrondir le temps à deux chiffres après la virgule
		timerText.GetComponent<TMP_Text>().text = " " + time.ToString("F2")  +"s";
	}
}
