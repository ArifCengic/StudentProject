using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace StudentDemo
{
    public static class Extensions
    {
        //To add a method to an existing class
        //without inheritance (creating a new class)
        // we use Decorator pattern 
        // in .NET we use extension methods
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
            // these two lines use different syntax but are same - execute same code)
            //string[] r = Extensions.getWords("juce, danas sutra");
            string[] res = "juce, danas sutra".getWords();

            List<Student> students = new List<Student> {
				new Student { ime = "Ana", ocjene = new int[] {2,5,0,7,5,4,3,6}, dob = new DateTime(1985,11,3) },
				new Student() { ime = "Jim", ocjene = new int[] {8,5,3,7,5,4,9,0}, dob = new DateTime(1995,12,3) },
                new Stipendista() { ime = "Ad", ocjene = new int[] {8,5,8,7,5,4,9,0}, dob = new DateTime(1980,1,3) },
                new Stipendista() { ime = "Jeff", ocjene = new int[] {8,5,8,7,5,4,9,0}, dob = new DateTime(1985,1,3) },
                new Stipendista() { ime = "Ali", ocjene = new int[] {8,9,8,7,7,4,9,0}, dob = new DateTime(1985,1,3) },
                new Student() { ime = "Jane", ocjene = new int[] {8,5,5,7,5,4,9,7}, dob = new DateTime(1975,12,3) },
            };
            XmlSerializer ser = new XmlSerializer(typeof(Student));
            Stream stream = new FileStream("student.xml", FileMode.Create);
            ser.Serialize(stream, students[0]);

            //using static class variable 
            Stipendista.minProsjek = 5.2;
            var some = new { name = "car", weight = 5000 };

            var query = students
                .Where(x => x.getAverage() > 2)
                .OrderBy(x => x.ime)
                .Take(3);
       

            //Function references (pointers)
            //Func(Student,bool) function that returns bool and takes 1 argument
            //bool Func (Student s) Same function described in a different way
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
            //factory pattern
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
