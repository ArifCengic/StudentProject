using System;
using System.Collections.Generic;

namespace StudentDemo
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Student> students = new List<Student> {
				new Student { ime = "Ana", ocjene = new int[] {2,5,0,7,5,4,3,6}, dob = new DateTime(1985,11,3) },
				new Student() { ime = "Jim", ocjene = new int[] {8,5,3,7,5,4,9,6}, dob = new DateTime(1995,12,3) }
			};

			double a = students[0].d * 0.1;
			Student s = new Stipendista();
			s.ime = "Amy";
			s.dob = students[0].dob;
			s.ocjene = students[0].ocjene;
			s.ocjene[2] = 10;

			students.Add(s);
			decimal sum = 0;
			foreach (Student st in students)
			{
				Console.WriteLine(st.toString());
				sum += st.calculatePayment();
			}
			Func<int, bool> f = n => n < 5;

			double dsum = 0;
			students.Sort((Student x, Student y) => x.getAverage().CompareTo(y.getAverage()) );

			students.ForEach(st => { Console.WriteLine(st.toString()); dsum += dsum + st.getAverage(); });
			students.TrueForAll(x => x.ime.Length == 3);


			var fs = students.Find(x  => x.ime == "Ana");
			//Console.WriteLine(fs.toString());
			if (a == 1) Console.WriteLine("Equal value");
			else Console.WriteLine("Not Equal value");
			Console.WriteLine("Total " + sum + "\n" + "--- Done! ---");
			Console.ReadLine();

		}
	}
}
