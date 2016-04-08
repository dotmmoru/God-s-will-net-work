using UnityEngine;
using System.Collections;
using SmartLocalization;
using UnityEngine.UI;

public class TextLocalizeHelper : MonoBehaviour
{
		public static string GetStringById (string stringFormatId)
		{
				LanguageManager m = GetInstance ();

				return m.GetTextValue (stringFormatId);
		}

		public string prefix;

		public static LanguageManager m;

		public string localizeId;
		public object[] parameters = new object[0];

		public void SetLocalizeId (string localizeId, params object[] parameters)
		{
				this.localizeId = localizeId;

				this.parameters = parameters;

				UpdateText ();
		}

		EventManager.EventWrapper languageListener;

		void OnEnable ()
		{
				UpdateText ();

				languageListener = new EventManager.EventWrapper (delegate(MyEvent myEvent) {
						UpdateText ();
				});
				EventManager.instance.Listen (EventManager.SYSTEM_LANGUAGE_CHANGED, languageListener);


		}

		void OnDisable ()
		{
				EventManager.instance.DestroyListener (EventManager.SYSTEM_LANGUAGE_CHANGED, languageListener);
		}

		 
		void Start ()
		{
		
		
				UpdateText ();
		}

		public static LanguageManager GetInstance ()
		{
				if (!LanguageManagerInitialized ()) {
						InitLanguageManager ();
				}

				return m;

		}

		void UpdateText ()
		{
				if (!LanguageManagerInitialized ()) {
						InitLanguageManager ();
				}

				if (localizeId != null && !localizeId.Equals ("")) {
						string textValue = m.GetTextValue (localizeId);

						Text text = this.GetComponent<Text> ();
						if (parameters != null && parameters.Length > 0) {
								text.text = string.Format (textValue, parameters);
						} else {
								text.text = textValue;
						}

						text.text = prefix + text.text;
				}

		}

		static void  InitLanguageManager ()
		{
				m = LanguageManager.Instance;


				string langCode = null;

				langCode = "";

				if (langCode == null) {
						langCode = m.GetSupportedSystemLanguageCode ();
				}

			
				if (langCode != null && m.IsLanguageSupported (langCode)) {
						m.ChangeLanguage (langCode);
				}

		}

		static bool  LanguageManagerInitialized ()
		{
				return m != null;
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
