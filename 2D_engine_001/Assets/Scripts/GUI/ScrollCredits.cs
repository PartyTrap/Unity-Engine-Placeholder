using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrollCredits : MonoBehaviour {

	public float speed = 0f;
	public float stop = 0f;
	public float stop2 = 0f;
	private TextMesh c;
	public GameObject thanks;
	public GameObject pos;
	public string scene;

	void Start () 
	{
		c = this.GetComponent<TextMesh> ();
		c.richText = true;
		StartCoroutine (Scroll());
	}

	void Update()
	{
		if (this.transform.position.y >= stop) 
		{
			this.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			c.text = "";
			if (GameObject.Find ("Thanks(Clone)") == null) 
			{
				GameObject thanksss;
				thanksss = (Instantiate(thanks, pos.transform.position, pos.transform.rotation))as GameObject;
				SceneManager.LoadScene (scene);

			}
		}
	}

	IEnumerator Scroll()
	{
		c.text = "<b>The Gauntlet (Gauntlet?)Im not too sure.</b>\n\n\n";

		c.text += "<b>Creative Directors</b>\n\n";
		c.text += "Areo Speedwag\nAustin Eathorne\nEvan Grinbergs\nJack Wiebe\nJohnny Nguyen\nKaiya Morgulis\nNeil Hansen\nRaven McBride\n\n";

		c.text += "<b>Producer</b>\n\n";
		c.text += "Johhny Von Speedwag\n\n\n";
		 
		c.text += "<b>Level Design</b>\n\n";
		c.text += "Rareo Nguyen\nEvtin Wiebulis\n\n\n";

		c.text += "<b>Gameplay Design</b>\n\n";
		c.text += "Kaiya McHanbergs\nNeil Bridethorne\nJacknny Raven\n\n\n";

		c.text += "<b>Programming</b>\n\n";
		c.text += "Neberg Kaitin\nTim Ravohnny\nJack Mcthornsen\n\n\n";

		c.text += "<b>Art and Animation</b>\n\n";
		c.text += "Grinmor Wiebewag\nAustin McEvanberg\nYareo Von Nguyen\n\n";

		c.text += "<b>Music</b>\n\n";
		c.text += "Evan Grinbergs\nSpencer Moody\n\n\n\n";

		c.text += "<b>Special Thanks</b>\n\n";
		c.text += "Minnesota Facewash\n" +
				"";

		yield return new WaitForSeconds (1.0f);
		this.GetComponent<Rigidbody2D> ().AddForce(Vector2.up * speed);
	}

}
