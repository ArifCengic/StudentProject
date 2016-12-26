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
				new Student() { ime = "Jim", ocjene = new int[] {8,5,3,7,5,4,9,0}, dob = new DateTime(1995,12,3) },
                new Stipendista() { ime = "Sam", ocjene = new int[] {8,5,8,7,5,4,9,0}, dob = new DateTime(1985,1,3) }
            };

            Stipendista.minProsjek = 5.2;
            /*****
            for(int i=0; i < 5; i++)
            {
                Console.WriteLine("Do you want to add new student");
                string response = Console.ReadLine();
                if (response.StartsWith("y"))
                {
                    Student s = null;
                    Console.WriteLine("Tip Studenta S-stipendista, V-vandredni, R-regularni");
                    string tip = Console.ReadLine();
                    switch(tip[0])
                    {
                        case 'R':
                            s = new Student();
                            break;
                        case 'S':
                            s = new Stipendista();
                            break;
                        case 'V':
                            s = new Vandredni();
                            break;
                        default:
                            break;
                    }
                    if(s != null) students.Add(s);
                }
                else
                {
                    Console.WriteLine("Unos zavrsen");

                    break;
                }
		****/
			decimal sum = 0;
            int countStipendista = 0;
			foreach (Student st in students)
			{
                if (st is Stipendista) countStipendista++;
            
                Console.WriteLine(st.toString());
				sum += st.calculatePayment();
			}
			


			//var fs = students.Find(x  => x.ime == "Ana");
			//Console.WriteLine(fs.toString());
			
			Console.WriteLine("Total " + sum + "\n" + "--- Done! ---");
			Console.ReadLine();

		}
	}
}
