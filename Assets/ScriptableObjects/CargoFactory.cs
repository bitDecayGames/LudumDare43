using System;
using System.Collections.Generic;
using Cargo;
using UnityEngine;

namespace ScriptableObjects {
	
	[CreateAssetMenu(menuName = "CargoFactory", order = 1)]
	public class CargoFactory : ScriptableObject {
		public List<Cargo> cargo;
		
		public CargoBehaviour ByName(string name) {
			if (name != null) {
				var index = cargo.FindIndex(c => c.name.ToLower().Equals(name.ToLower()));
				if (index >= 0) return cargo[index].cargo;
			}
			return null;
		}

		public CargoBehaviour ByName(string name, int score) {
			var cargo = ByName(name);
			if (cargo != null) cargo.score = score;
			return cargo;
		}
	}

	[Serializable]
	public struct Cargo {
		public string name;
		public CargoBehaviour cargo;

		public Cargo(string name, CargoBehaviour cargo) {
			this.name = name;
			this.cargo = cargo;
		}
	}
}
