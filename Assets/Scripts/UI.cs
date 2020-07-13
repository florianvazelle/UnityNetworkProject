using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

  static public UI Instance;

  public GameObject canvas;
  public GameObject text;

  void Start () {
    Instance = this;
  }

  public void addPlayer (int id) {
    UI.Instance.text.name = "Joueur" + id;
    GameObject label = Instantiate (UI.Instance.text);
    label.transform.parent = UI.Instance.canvas.transform;

    Text text;
    text = label.GetComponent<Text> ();
    text.text = "Joueur " + id + " : ";

    RectTransform rectTransform;
    rectTransform = text.GetComponent<RectTransform> ();
    rectTransform.anchoredPosition3D = new Vector3 (10, 20 * -id, 0);
  }

  public void updatePlayerScore (int id) {
    GameObject score = GameObject.Find ("Joueur" + id + "(Clone)/score");

    Text text;
    text = score.GetComponent<Text> ();
    text.text = "" + (int.Parse (text.text) + 1);
  }
}