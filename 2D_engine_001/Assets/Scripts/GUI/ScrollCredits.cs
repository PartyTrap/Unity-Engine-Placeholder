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
	private int fontSize;

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

				StartCoroutine(LoadScene());
			}
		}
	}

	IEnumerator Scroll()
	{
		c.text += "<b>The Gauntlet</b>\n\n\n";

		c.text += "<b>Creative Directors</b>\n\n";
		c.text += "Tim 'Areo Speedwag' Fernando\nAustin Eathorne\nEvan Grinbergs\nJack Wiebe\nJohnny Nguyen\nKaiya Morgulis\nNeil Hansen\nRaven McBride\n\n\n";

		c.text += "<b>Professional Bird Keeper</b>\n\n";
		c.text += "Johhny Von Speedwag\n\n\n";

		c.text += "<b>Beauty Boys</b>\n\n";
		c.text += "Rareo Nguyen\nEvtin Wiebulis\n\n\n";

		c.text += "<b>European Marketing Team</b>\n\n";
		c.text += "Kaiya McHanbergs\nNeil Bridethorne\nJacknny Raven\n\n\n";

		c.text += "<b>In House Orchestra</b>\n\n";
		c.text += "Neberg Kaitin\nTim Ravohnny\nJack Mcthornsen\n\n\n";

		c.text += "<b>Sanitation Engineers</b>\n\n";
		c.text += "Grinmor Wiebewag\nAustin McEvanberg\nYareo Von Nguyen\n\n\n";

		c.text += "<b>Beard Stylist</b>\n\n";
		c.text += "Timtin Bridesen\n\n\n";

		c.text += "<b>Goat Transporter</b>\n\n";
		c.text += "Jason Statham\n\n\n";

		c.text += "<b>Music</b>\n\n";
		c.text += "Spencer Moody : RecRecStudio.com\nEvan Grinbergs\n\n\n\n";

		c.text += "<b>Special Thanks</b>\n\n";
		c.text += "Minnesota Facewash, Muffin Man, Hideo Kojima,\n" +
			"'The Academy', Samuel L Jackson, eSports,\n" +
			"Evan Grinsberg, One Punch, Smoke Breaks,\n" +
			"Powerthirst, Hideo Kojima, Waifus, Robin,\n" +
			"Wizards of the Coast, Ben Kenobi, GoldMember,\n" +
			"That One Dude, Tim Hortons Express, GitHub,\n" +
			"Fil Krstevski, Alex Richard, Peggy Hill,\n" +
			"George Lucas, George Costanza, George Foreman,\n" +
			"Dorritos, MLG, Mountain Dew,\n" +
			"Hideo Kojima, Joe Sakic, Patty Roy,\n" +
			"BLOOOODBOOOOOOORNEEEEEEEEEEEEE,\n" +
			"Pokemon, XPANDONG, Lankey Kang,\n" +
			"Myrdyr, Sleep, Fucking Human Biology,\n" +
			"Hideo Kojima, Love, Hideo Kojima,\n" +
			"Gordon Freeman, Simone Munro, Shovel Knight,\n" +
			"You Guys, Twitch Plays Pokemon, Smack,\n" +
			"Love Handles, Love Force, Love Generation,\n" +
			"End of Ze World, Herpgero, YO FUCK DIS GUI\n" +
			"BABY YOU'RE A 0.7, FEE Games, TuPac,\n" +
			"Myself, Jean-Luc Picard, and Hideo Kojima";

		yield return new WaitForSeconds (2.0f);
		this.GetComponent<Rigidbody2D> ().AddForce(Vector2.up * speed);
	}

	IEnumerator LoadScene()
	{
		yield return new WaitForSeconds (5.0f);
		SceneManager.LoadScene (scene);
	}

}
//RecRecStudio.com