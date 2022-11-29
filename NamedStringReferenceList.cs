using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

	[System.Serializable]
	public class NamedStringReference{
		public string Name;
		public StringReference StringReference;
		public NamedStringReference(string _name,string _value){
			Name = _name;
			StringReference.Value = _value;
			StringReference.UseConstant = true;
		}
	}

[CreateAssetMenu]
public class NamedStringReferenceList : ScriptableObject
{

	
	public List<NamedStringReference> NamedStringReferences;
	
	public StringStringDictionaryEvent DictionaryEvent;
	
	public Dictionary<string,string> Dictionary;
	
	public void SaveToDictionary(){
		//Debug.Log("save dicationary");
		Dictionary = new Dictionary<string, string>();
		foreach(NamedStringReference namedString in NamedStringReferences){
			Dictionary.Add(namedString.Name,namedString.StringReference);
		}
		DictionaryEvent.Invoke(Dictionary);
	}
	
	public void SetValues(Dictionary<string,string> input){
		foreach(NamedStringReference nsr in NamedStringReferences){
			if(input.ContainsKey(nsr.Name)){
				//Debug.Log(input[nsr.Name] + " " + nsr.StringReference.Value);
				nsr.StringReference.Value = input[nsr.Name];
			}
		}
	}
}
