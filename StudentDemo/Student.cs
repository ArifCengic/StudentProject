﻿using System;
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

		public int getAttendance()
		{
			//Track attendance
			return 100; //100%
		}
		public double getAverage()
		{
			double sum = 0;
			for (int i = 0; i < ocjene.Length; i++)
			{
				sum = sum + ocjene[i];
			}

			return sum / ocjene.Length;
		}

		virtual public decimal calculatePayment()
		{
			return 2500;
		}

		public string toString(){
			string res =  "Student " + ime + " rodjen " + dob.ToLongDateString() + " prosjek " + getAverage();
			// res = res + " ocjene: ";
			// foreach (var o in this.ocjene) res = res + o + ", ";
			return res;
		}

		//static public bool operator ==(Student a, Student b)
		//{
		//	if(a.ime == b.ime) return true;
		//	else return false;
		//}

		//static public bool operator !=(Student a, Student b)
		//{
		//	if (a.ime == b.ime) return false;
		//	else return true;
		//}

	}

	public class Stipendista : Student {
	override public decimal calculatePayment()
		{
			if (getAverage() >= 4.5) return 100;
			else return 2500;
		}
	}

	public class Vandredni : Student
	{
		
	}



}


