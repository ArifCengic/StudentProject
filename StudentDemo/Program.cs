using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentDemo
{
    public static class Extensions
    {
    public static string[] getWords(this string s)
    {
        string[] res = s.Split(new char[] { ',', ' ', '.' });
        return res;
    }
    }
    class MainClass
	{
       

		public static void Main(string[] args)
		{

           //string[] r = Extensions.getWords("juce, danas sutra");
           
			List<Student> students = new List<Student> {
				new Student { ime = "Ana", ocjene = new int[] {2,5,0,7,5,4,3,6}, dob = new DateTime(1985,11,3) },
				new Student() { ime = "Jim", ocjene = new int[] {8,5,3,7,5,4,9,0}, dob = new DateTime(1995,12,3) },
                new Stipendista() { ime = "Ad", ocjene = new int[] {8,5,8,7,5,4,9,0}, dob = new DateTime(1980,1,3) },
                new Stipendista() { ime = "Jeff", ocjene = new int[] {8,5,8,7,5,4,9,0}, dob = new DateTime(1985,1,3) },
                new Stipendista() { ime = "Ali", ocjene = new int[] {8,9,8,7,7,4,9,0}, dob = new DateTime(1985,1,3) },
                new Student() { ime = "Jane", ocjene = new int[] {8,5,5,7,5,4,9,7}, dob = new DateTime(1975,12,3) },
            };

            Stipendista.minProsjek = 5.2;
            var some = new { name = "car", weight = 5000 };

            var query = students
                .Where(x => x.getAverage() > 2)
                .OrderBy(x => x.ime)
                .Take(3);
       

           // var fs = students.FindAll(x => x.ime.StartsWith("A") && x.getAverage() > 2);
           //     fs.Sort( (x, y) => x.ime.CompareTo(y.ime));
            //Func(Student,bool)
            //bool Func (Student s)
            decimal sum = 0;
            int countStipendista = 0;
            foreach (Student st in query)
            {
                if (st is Stipendista)
                {
                    countStipendista++;
                    Stipendista stip = (Stipendista)st;
                    Console.WriteLine(stip.toString());
                }
                else Console.WriteLine(st.toString());
                sum += st.calculatePayment();
            }

            
            //Console.WriteLine(fs.toString());

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

            Console.WriteLine("Total " + sum + "\n" + "--- Done! ---");
			Console.ReadLine();

		}
	}
}
