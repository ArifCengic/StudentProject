using System;
namespace StudentDemo
{
	public class Student
	{
			public string ime;
			public int[] ocjene = new int[10];
			int visinaCM;
			string fakultet;
			public DateTime dob;
		decimal skolarina;
		public double d = 10;
		bool isMale;

		public double getAverage()
		{
			double sum = 0;
			for (int i = 0; i < ocjene.Length; i++)
			{
				sum = sum + ocjene[i];
			}

			return sum / ocjene.Length;
		}

		 public decimal calculatePayment()
		{
			return 2500;
		}
		public string toString(){
			string res =  "Student " + ime + " rodjen " + dob.ToLongDateString() + " prosjek " + getAverage();
			// res = res + " ocjene: ";
			// foreach (var o in this.ocjene) res = res + o + ", ";
			return res;
		}
	}

	public class Stipendista : Student {
	 public decimal calculatePayment()
		{
			if (getAverage() >= 4.5) return 100;
			else return 2500;
		}
	}

}


