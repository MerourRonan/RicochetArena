using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FloatingDisplay : MonoBehaviour {

	protected Text m_FloatingText;

	// Use this for initialization
	void Awake () {
		m_FloatingText = transform.Find ("Text").GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveAndFade ();
	}

	protected void moveAndFade()
	{
		transform.GetComponent<RectTransform>().anchoredPosition+= Vector2.up * Time.deltaTime*16;
		GetComponent<CanvasGroup> ().alpha -= Time.deltaTime;
		if (GetComponent<CanvasGroup> ().alpha <= 0) {
			Destroy (this.gameObject);
		}

	}

	public void init(Vector3 pos,string symbole,int value)
	{
		transform.position =  Camera.main.WorldToScreenPoint (pos);
		m_FloatingText.text = symbole + value.ToString ();
	}
}
