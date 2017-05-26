using UnityEngine;

namespace Temple {
	public class Agent {
		Vector2 location;
		Vector2 velocity;
		Vector2 acceleration;

		float maxSpeed;

		Species species;

		public Species Species { get { return species; }}
		public Vector2 Location { get { return location; }}

		public Agent(Vector2 birthplace, float speed, Species species) {
			this.location = birthplace;
			this.velocity = Vector2.zero;
			this.acceleration = Vector2.zero;
			this.maxSpeed = speed;
			this.species = species;
		}

		public void UpdateLocation() {
			UpdateAcceleration ();
			UpdateVelocity ();
			this.location += this.velocity;
			ResetAcceleration ();
		}

		void AddForce(Vector2 force) { this.acceleration += force; }

		void SetForce(Vector2 force) { this.acceleration = force; }

		void UpdateAcceleration() {
			AddForce (new Vector2(0, 1));
		}

		void ResetAcceleration() { SetForce (Vector2.zero); }

		void UpdateVelocity() {
			this.velocity += this.acceleration;
			this.velocity.x = Mathf.Clamp (this.velocity.x, -maxSpeed, maxSpeed);
			this.velocity.y = Mathf.Clamp (this.velocity.y, -maxSpeed, maxSpeed);
			this.velocity *= Time.deltaTime;
		}
	}//end class Agent
}//end namespace Temple