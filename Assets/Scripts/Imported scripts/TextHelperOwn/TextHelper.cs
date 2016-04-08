using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//
//[RequireComponent (FontSizeHelper)]
//[RequireComponent (TextLocalizeHelper)]
using System.Text;


public class TextHelper : MonoBehaviour
{
	
		public bool init = false;

		public FontSize fontSize = FontSize.TEXT;

		public void SetLocalizeId (string toggleTextEnabledId, params object[] parameters)
		{
				localizeId = toggleTextEnabledId;
				TextLocalizeHelper textLocalizeHelper = this.gameObject.GetComponent <TextLocalizeHelper> ();
				textLocalizeHelper.SetLocalizeId (localizeId, parameters);

		}

		public string localizeId;
			

		// Use this for initialization
		void OnEnable ()
		{

				if (!init) {
						init = true;
						FontSizeHelper fontSizeHelper = this.gameObject.AddComponent <FontSizeHelper> ();
						fontSizeHelper.size = fontSize;

						TextLocalizeHelper textLocalizeHelper = this.gameObject.AddComponent <TextLocalizeHelper> ();
						textLocalizeHelper.localizeId = localizeId;
				}


		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public static string GetLine (Dictionary<string, object> d)
		{
				return GetLineRecurs (d, 0);
		}

		public static string GetLineRecurs (Dictionary<string, object> d, int level)
		{
				// Build up each line one-by-one and then trim the end
				StringBuilder builder = new StringBuilder ();
				for (int i = 0; i < level; i++) {
						builder.Append ("\t");
				}
				builder.Append ("{");
				foreach (KeyValuePair<string, object> pair in d) {
						builder.Append ("\n");
						for (int i = 0; i < level; i++) {
								builder.Append ("\t");
						}
						if (pair.Value is Dictionary<string, object>) {
								builder.Append (pair.Key).Append (":").Append (GetLineRecurs (pair.Value as Dictionary<string, object>, level + 1)).Append (',');
						} else if (pair.Value is Dictionary<string, string>) {
								builder.Append (pair.Key).Append (":").Append (GetLineRecurs (pair.Value as Dictionary<string, string>, level + 1)).Append (',');
						} else if (pair.Value is Dictionary<string, int>) {
								foreach (KeyValuePair<string, int> pairInt in pair.Value as Dictionary<string, int>) {
										builder.Append ("\n");
										for (int i = 0; i < level + 1; i++) {
												builder.Append ("\t");
										}
										builder.Append (pairInt.Key).Append (":").Append (pairInt.Value).Append (',');
						
								}
						
						} else {
								builder.Append (pair.Key).Append (":").Append (pair.Value).Append (',');
						}


				}
				for (int i = 0; i < level; i++) {
						builder.Append ("\t");
				}
				builder.Append ("}");
				string result = builder.ToString ();
				// Remove the final delimiter
				result = result.TrimEnd (',');
				return result;
		}

		public static string GetLineRecurs (Dictionary<string, string> d, int level)
		{
				// Build up each line one-by-one and then trim the end
				StringBuilder builder = new StringBuilder ();
				foreach (KeyValuePair<string, string> pair in d) {
						builder.Append ("\n");
						for (int i = 0; i < level; i++) {
								builder.Append ("\t");
						}
					
						builder.Append (pair.Key).Append (":").Append (pair.Value).Append (',');
						


				}
				string result = builder.ToString ();
				// Remove the final delimiter
				result = result.TrimEnd (',');
				return result;
		}

		public static string GetRomanNumber (int number)
		{
			
 				
				StringBuilder result = new StringBuilder ();
				int[] digitsValues = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
				string[] romanDigits = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };
				while (number > 0) {
						for (int i = digitsValues.Length - 1; i >= 0; i--)
								if (number / digitsValues [i] >= 1) {
										number -= digitsValues [i];
										result.Append (romanDigits [i]);
										break;
								}
				}
				return result.ToString ();
		}

		public static string FormatSeccondsTime (float time)
		{
				string formatTimerLessOneMinute = "{0:0}";
				string formatTimerMoreOneMinute = "{0:0}:{1:00}";

				string timeText;
 				
				if (time < 60) {
						timeText = string.Format (formatTimerLessOneMinute, time);
				} else {
						int sec = (int)(time % 60);
						int min = (int)(time / 60);
						timeText = string.Format (formatTimerMoreOneMinute, min, sec);
				}

				return timeText;

		}

		public static string FormatSeccondsTimeWithMinutes (float time)
		{
				
				string formatTimerMoreOneMinute = "{0:0}:{1:00}";

				string timeText;
 				
		
				int sec = (int)(time % 60);
				int min = (int)(time / 60);
				timeText = string.Format (formatTimerMoreOneMinute, min, sec);
				

				return timeText;

		}
}
