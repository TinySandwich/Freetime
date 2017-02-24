using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("chassis")]
public class StarshipCollection {

	[XmlArray("Starships"), XmlArrayItem("Starship")]
	public Starship[] Starships;
	//public List<Starship> myStarships = new List<Starship> ();

	public static StarshipCollection Load (string path) {
		var serializer = new XmlSerializer (typeof(StarshipCollection));
		using (var stream = new FileStream (path, FileMode.Open)) {
			return serializer.Deserialize (stream) as StarshipCollection;
		}	
	}

	public Starship getStarship (string chassisName) {
		Starship newStarship = new Starship ();



		return newStarship;
	}
}
